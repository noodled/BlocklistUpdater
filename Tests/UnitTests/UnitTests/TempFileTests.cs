using System.IO;
using BlocklistUpdater.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocklistUpdater.Tests.UnitTests
{
    [TestClass]
    public class TempFileTests
    {
        [TestMethod]
        public void Creates_temp_file_on_construction()
        {
            using (var temp = new TempFile())
            {
                Assert.IsNotNull(temp.File);
                Assert.IsTrue(temp.File.Exists);
            }
        }

        [TestMethod]
        public void Removes_self_when_disposed()
        {
            FileInfo file = null;
            using (var temp = new TempFile())
            {
                Assert.IsNotNull(temp.File);
                file = temp.File;
                Assert.IsTrue(temp.File.Exists);
            }
            Assert.IsNotNull(file);
            file.Refresh();
            Assert.IsFalse(file.Exists);
        }
    }
}