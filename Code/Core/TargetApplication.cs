using System;
using System.IO;

namespace BlocklistUpdater.Core
{
    /// <summary>
    /// Generic implementation of an application that consumes
    /// a blocklist.
    /// </summary>
    public class TargetApplication : ITargetApplication
    {
        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <value>The application name.</value>
        public virtual string Name { get; private set; }

        /// <summary>
        /// Updates the application's blocklist with the specified blocklist file.
        /// </summary>
        /// <param name="blocklistFile">The updated blocklist file.</param>
        public virtual void Update(FileInfo blocklistFile)
        {
            if (blocklistFile == null) throw new ArgumentNullException("blocklistFile");
            if (TargetFile == null) throw new InvalidOperationException("The TargetFile is not set for the application");

            blocklistFile.CopyTo(TargetFile.FullName, true);
        }

        /// <summary>
        /// Gets or sets the target file. The updated block list will
        /// be copied to this location.
        /// </summary>
        /// <value>The target file.</value>
        public virtual FileInfo TargetFile { get; set; }
    }
}