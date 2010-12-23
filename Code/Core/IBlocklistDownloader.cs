namespace BlocklistUpdater.Core
{
    public interface IBlocklistDownloader
    {
        /// <summary>
        /// Updates the specified blocklist, downloading it to a temporary file.
        /// </summary>
        /// <param name="blocklist">The blocklist to update.</param>
        /// <returns>A temporary file containing the latest version of the blocklist.</returns>
        TempFile Update(Blocklist blocklist);
    }
}