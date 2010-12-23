using System;
using BlocklistUpdater.Core.Properties;

namespace BlocklistUpdater.Core
{
    public class BlocklistUpdaterService : IBlocklistUpdaterService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlocklistUpdaterService"/> class.
        /// </summary>
        public BlocklistUpdaterService() : this(new ListManager()) {}

        public BlocklistUpdaterService(IListManager listManager)
        {
            Blocklists = new BlocklistCollection();
            TargetApplications = new TargetApplicationCollection();
            ListManager = listManager;
        }

        public void Update()
        {
            if( TargetApplications == null || TargetApplications.Count == 0) throw new UpdateException(Resources.NoTargetApplicationsException);

            ListManager.GetLatestVersionOf(Blocklists);
        }

        public TargetApplicationCollection TargetApplications { get; private set; }

        public BlocklistCollection Blocklists { get; set; }

        public IListManager ListManager { get; set; }
    }
}