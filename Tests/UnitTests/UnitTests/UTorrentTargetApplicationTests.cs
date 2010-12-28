using System;
using System.IO;
using BlocklistUpdater.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocklistUpdater.Tests.UnitTests
{
    [TestClass]
    public class UTorrentTargetApplicationTests
    {
        [TestMethod]
        public void Name()
        {
            var app = new UTorrentTargetApplication();

            Assert.AreEqual(UTorrentTargetApplication.AppName, app.Name);
        }

        [TestMethod]
        public void TargetFile()
        {
            var app = new UTorrentTargetApplication();

            var target = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), UTorrentTargetApplication.IpFilterFileName);
            Assert.AreEqual(target, app.TargetFile.FullName);
        }
    }
}