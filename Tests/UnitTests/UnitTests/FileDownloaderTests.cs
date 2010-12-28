using System;
using BlocklistUpdater.Core;
using Microsoft.Practices.Prism.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BlocklistUpdater.Tests.UnitTests
{
    [TestClass]
    public class FileDownloaderTests
    {
        [TestMethod]
        public void Creates_default_EventAggregator()
        {
            var downloader = new FileDownloader();

            Assert.IsNotNull(downloader.EventAggregator);
        }

        [TestMethod]
        public void Constructor_takes_EventAggregator()
        {
            var aggregator = new Mock<IEventAggregator>();
            var downloader = new FileDownloader(aggregator.Object);
            Assert.AreEqual(aggregator.Object, downloader.EventAggregator);
        }

        [TestMethod]
        public void Initialize_gets_Progress_event()
        {
            var aggregator = new Mock<IEventAggregator>();
            var downloader = new FileDownloader(aggregator.Object);
            
            downloader.Initialize();

            aggregator.Verify(eventAggregator => eventAggregator.GetEvent<UpdateProgressEvent>());
            Assert.AreEqual(aggregator.Object, downloader.EventAggregator);
        }

        [TestMethod]
        public void Initialize_sets_flag()
        {
            var aggregator = new Mock<IEventAggregator>();
            var downloader = new FileDownloader(aggregator.Object);

            Assert.IsFalse(downloader.IsInitialized);
            downloader.Initialize();
            Assert.IsTrue(downloader.IsInitialized);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void Exception_if_trying_to_download_without_calling_Initialize_first()
        {
            var aggregator = new Mock<IEventAggregator>();
            var downloader = new FileDownloader(aggregator.Object);
            downloader.Download(new Uri("http://www.google.com/"));
        }
    }
}
