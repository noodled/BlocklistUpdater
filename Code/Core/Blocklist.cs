using System;
using System.Collections.Generic;

namespace BlocklistUpdater.Core
{
    public class Blocklist
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Uri> Sources { get; set; }

        public DateTime LastUpdated { get; set; }

        public DateTime LastDownloaded { get; set; }

        public string Author { get; set; }

        public Uri AuthorUri { get; set; }
    }
}