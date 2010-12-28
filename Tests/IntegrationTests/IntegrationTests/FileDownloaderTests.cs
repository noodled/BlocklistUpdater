using System;
using BlocklistUpdater.Core;
using Microsoft.Practices.Prism.Events;
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
            downloader.Initialize();
            using (var file = downloader.Download(new Uri("http://www.google.co.nz/")))
            {
                Assert.IsNotNull(file);
                file.File.Refresh();
                Assert.IsTrue(file.File.Length > 0);
            }
        }

        [TestMethod]
        public void Progress_event()
        {
            IEventAggregator aggregator = new EventAggregator();
            IFileDownloader downloader = new FileDownloader(aggregator);
            downloader.Initialize();
            var progressEvent = aggregator.GetEvent<UpdateProgressEvent>();

            int progressEventTimes = 0;

            progressEvent.Subscribe(state => progressEventTimes++);

            using (var file = downloader.Download(new Uri("http://www.google.co.nz/")))
            {
                Assert.IsNotNull(file);
                file.File.Refresh();
                Assert.IsTrue(file.File.Length > 0);
            }

            Assert.IsTrue(progressEventTimes > 0);
        }
    }
}