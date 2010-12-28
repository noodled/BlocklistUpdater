using BlocklistUpdater.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocklistUpdater.Tests.UnitTests
{
    [TestClass]
    public class UpdateStateTests
    {
        [TestMethod]
        public void Properties()
        {
            var state = new UpdateState();

            Assert.IsNull(state.Url);
            Assert.AreEqual(0, state.ProgressPercentage);
            Assert.IsNull(state.ProgressCaption);
        }
    }
}