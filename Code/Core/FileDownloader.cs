using System;
using System.Net;
using Microsoft.Practices.Prism.Events;

namespace BlocklistUpdater.Core
{
    public class FileDownloader : IFileDownloader
    {
        const int DefaultChunkSize = 32767;

        internal readonly IEventAggregator EventAggregator;
        private int chunkSize = DefaultChunkSize;
        UpdateProgressEvent progressEvent;
        internal bool IsInitialized;

        public FileDownloader(IEventAggregator eventAggregator)
        {
            this.EventAggregator = eventAggregator;
        }
        
        public FileDownloader() : this(new EventAggregator())
        {
        }

        public TempFile Download(Uri uri)
        {
            if (uri == null) throw new ArgumentNullException("uri");
            if( !IsInitialized) throw new InvalidOperationException("Downloader was not initialized with Initialize() before calling Download()");

            var request = (HttpWebRequest)WebRequest.Create(uri);

            request.UseDefaultCredentials = true;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            progressEvent.Publish(new UpdateState(uri, "Connecting...", 0));
            
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                var temp = new TempFile();
                using (var tempStream = temp.File.OpenWrite())
                {
                    var buffer = new byte[chunkSize];
                    int bytesRead;
                    while ((bytesRead = stream.Read(buffer, 0, chunkSize)) > 0)
                    {
                        tempStream.Write(buffer, 0, bytesRead);
                    }

                    return temp;
                }
            }
        }

        public void Initialize()
        {
            progressEvent = EventAggregator.GetEvent<UpdateProgressEvent>();
            IsInitialized = true;
        }
    }
}