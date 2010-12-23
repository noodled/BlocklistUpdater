using System;
using System.IO;

namespace BlocklistUpdater.Core
{
    public class ListManager : IListManager
    {
        public ListManager(IBlocklistDownloader blocklistDownloader)
        {
            BlocklistDownloader = blocklistDownloader;
        }

        public ListManager() : this(new BlocklistDownloader()) {}

        public FileInfo GetLatestVersionOf(BlocklistCollection blocklist)
        {
            if (blocklist == null) throw new ArgumentNullException("blocklist");

            foreach (var blockList in blocklist)
            {
                BlocklistDownloader.Update(blockList);
            }

            return new FileInfo( Path.GetTempFileName() );
        }

        public IBlocklistDownloader BlocklistDownloader { get; set; }
    }
}