using System;
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

        [TestMethod]
        public void TargetFile()
        {
            var target = new TargetApplication();
            Assert.IsNull(target.TargetFile);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Update_checks_banlist_file_for_null()
        {
            new TargetApplication().Update(null);
        }
    }
}