using System.IO;

namespace BlocklistUpdater.Core
{
    /// <summary>
    /// Represents an application that uses a blocklist.
    /// </summary>
    public interface ITargetApplication
    {
        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <value>The application name.</value>
        string Name { get; }

        /// <summary>
        /// Updates the application's blocklist with the specified blocklist file.
        /// </summary>
        /// <param name="blocklistFile">The updated blocklist file.</param>
        void Update(FileInfo blocklistFile);
    }
}