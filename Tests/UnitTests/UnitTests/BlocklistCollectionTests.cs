using BlocklistUpdater.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BlocklistUpdater.Tests.UnitTests
{
    [TestClass]
    public class BlocklistCollectionTests
    {
        [TestMethod]
        public void Add()
        {
            var blocklist = new Mock<Blocklist>();
            var collection = new BlocklistCollection();
            Assert.AreEqual(0, collection.Count);
            collection.Add(blocklist.Object);
            Assert.AreEqual(1, collection.Count);
            Assert.AreEqual(blocklist.Object, collection[0]);
        }
    }
}