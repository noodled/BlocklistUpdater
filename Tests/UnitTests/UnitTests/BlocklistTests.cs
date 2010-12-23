using System;
using System.Collections.Generic;
using BlocklistUpdater.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlocklistUpdater.Tests.UnitTests
{
    [TestClass]
    public class BlocklistTests
    {
        [TestMethod]
        public void Properties()
        {
            var list = new Blocklist
                           {
                               Name = "Name",
                               Description = "Description",
                               Sources = new List<Uri> { new Uri("http://list.iblocklist.com/?list=bt_level1")},
                               Author = "Bluetack",
                               AuthorUri = new Uri("http://bluetack.co.uk/")
                           };

            Assert.AreEqual(DateTime.MinValue, list.LastUpdated);
            Assert.AreEqual(DateTime.MinValue, list.LastDownloaded);
        }
    }
}