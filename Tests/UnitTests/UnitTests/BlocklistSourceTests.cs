using BlocklistUpdater.Core;

namespace BlocklistUpdater.Tests.UnitTests
{
    public class BlocklistSourceTests
    {
        public void Properties()
        {
            var source = new BlocklistSource("http://list.iblocklist.com/?list=bt_level1");
        }
    }
}