using System;
using System.IO;
using BlocklistUpdater.Core;

namespace BlocklistUpdater.Tests.UnitTests
{
    /// <summary>
    /// Support for updating the uTorrent IP Filter.
    /// </summary>
    public class UTorrentTargetApplication : TargetApplication
    {
        internal const string AppName = "uTorrent";

        FileInfo targetFile;
        internal const string IpFilterFileName = "ipfilter.dat";

        /// <summary>
        /// Initializes a new instance of the <see cref="UTorrentTargetApplication"/> class.
        /// </summary>
        public UTorrentTargetApplication()
        {
            targetFile = new FileInfo( Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), IpFilterFileName) );
        }

        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <value>The application name.</value>
        public override string Name
        {
            get { return AppName; }
        }

        /// <summary>
        /// Gets or sets the target file. The updated block list will
        /// be copied to this location.
        /// </summary>
        /// <value>The target file.</value>
        public override FileInfo TargetFile
        {
            get
            {
                return targetFile;
            }
            set
            {
                targetFile = value;
            }
        }
    }
}