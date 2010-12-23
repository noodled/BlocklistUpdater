using BlocklistUpdater.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocklistUpdater.Tests.UnitTests
{
    [TestClass]
    public class TargetApplicationTests
    {
        [TestMethod]
        public void Properties()
        {
            ITargetApplication target = new TargetApplication();
            Assert.IsNull(target.Name);
        }
    }
}