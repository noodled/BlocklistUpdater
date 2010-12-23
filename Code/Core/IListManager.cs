using System.IO;

namespace BlocklistUpdater.Core
{
    public interface IListManager
    {
        FileInfo GetLatestVersionOf(BlocklistCollection blocklist);
        IBlocklistDownloader BlocklistDownloader { get; set; }
    }
}