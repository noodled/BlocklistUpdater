using System;

namespace BlocklistUpdater.Core
{
    public interface IFileDownloader
    {
        TempFile Download(Uri uri);
    }
}