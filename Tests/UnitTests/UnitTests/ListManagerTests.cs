using System.Text;
using System.Collections.Generic;
using System.Linq;
using BlocklistUpdater.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BlocklistUpdater.Tests.UnitTests
{
    [TestClass]
    public class ListManagerTests
    {
        [TestMethod]
        public void GetLatestVersionOf_returns_temp_file_containing_list_data()
        {
            var list = new Mock<BlocklistCollection>();
            IListManager manager = new ListManager();
            var file = manager.GetLatestVersionOf(list.Object);
            Assert.IsNotNull(file);
            Assert.IsTrue(file.Exists);
            Assert.IsTrue(file.Length > 0);
        }

        [TestMethod]
        public void Uses_default_BlocklistDownloader()
        {
            IListManager manager = new ListManager();
            Assert.IsNotNull(manager.BlocklistDownloader);
        }

        [TestMethod]
        public void Constructor_takes_BlocklistDownloader()
        {
            
            var downloader = new Mock<IBlocklistDownloader>();
            IListManager manager = new ListManager(downloader.Object);
            Assert.AreEqual(downloader.Object, manager.BlocklistDownloader);
        }

        [TestMethod]
        public void GetLatestVersionOf_invokes_download_for_each_list()
        {
            var list1 = new Mock<Blocklist>();
            var list2 = new Mock<Blocklist>();

            var list = new BlocklistCollection{list1.Object, list2.Object};

            var downloader = new Mock<IBlocklistDownloader>();

            IListManager manager = new ListManager(downloader.Object);
            manager.GetLatestVersionOf(list);
            
            downloader.Verify(blocklistDownloader => blocklistDownloader.Update(list1.Object),Times.Once());
            downloader.Verify(blocklistDownloader => blocklistDownloader.Update(list2.Object),Times.Once());
        }
    }
}
