using BlocklistUpdater.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BlocklistUpdater.Tests.UnitTests
{
    [TestClass]
    public class TargetApplicationCollectionTests
    {
        [TestMethod]
        public void Add()
        {
            var target = new Mock<ITargetApplication>();
            var collection = new TargetApplicationCollection();
            Assert.AreEqual(0, collection.Count);
            collection.Add(target.Object);
            Assert.AreEqual(1, collection.Count);
            Assert.AreEqual(target.Object, collection[0]);
        }
    }
}