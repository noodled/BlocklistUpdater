using System;

namespace BlocklistUpdater.Core
{
    public interface IFileDownloader : ICanInitialize
    {
        TempFile Download(Uri uri);
    }
}