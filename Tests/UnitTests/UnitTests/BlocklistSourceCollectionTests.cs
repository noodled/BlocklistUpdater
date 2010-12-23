using BlocklistUpdater.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocklistUpdater.Tests.UnitTests
{
    [TestClass]
    public class BlocklistSourceCollectionTests
    {
        private const string SourceUrl = "http://list.iblocklist.com/?list=bt_level1";

        [TestMethod]
        public void Add()
        {
            var source = new BlocklistSource(SourceUrl);

            var collection = new BlocklistSourceCollection();
            Assert.AreEqual(0, collection.Count);
            collection.Add(source);
            Assert.AreEqual(1, collection.Count);
        }
    }
}