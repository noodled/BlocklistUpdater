using System;
using System.IO;

namespace BlocklistUpdater.Core
{
    public class TempFile : IDisposable
    {
        public TempFile()
        {
            File = new FileInfo(Path.GetTempFileName());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing || File == null) return;
            File.Refresh();
            if (!File.Exists) return;
            File.Delete();
        }

        public FileInfo File { get; set; }
    }
}