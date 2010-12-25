using System;
using BlocklistUpdater.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocklistUpdater.Tests.IntegrationTests
{
    [TestClass]
    public class FileDownloaderTests
    {
        [TestMethod]
        public void Download()
        {
            IFileDownloader downloader = new FileDownloader();

            using (var file = downloader.Download(new Uri("http://www.google.co.nz/")))
            {
                Assert.IsNotNull(file);
                file.File.Refresh();
                Assert.IsTrue(file.File.Length > 0);
            }
        }
    }
}