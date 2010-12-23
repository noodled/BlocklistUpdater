using System;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using BlocklistUpdater.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocklistUpdater.Tests.UnitTests
{
    [TestClass]
    public class FileDownloaderTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IFileDownloader downloader = new FileDownloader();
        }
    }

    public interface IFileDownloader
    {
        TempFile Download(Uri uri);
    }

    public class FileDownloader : IFileDownloader
    {
        private int chunkSize = DefaultChunkSize;
        const int DefaultChunkSize = 32767;

        public TempFile Download(Uri uri)
        {
            if (uri == null) throw new ArgumentNullException("uri");

            var request = (HttpWebRequest)WebRequest.Create(uri);

            request.UseDefaultCredentials = true;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

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
    }
}