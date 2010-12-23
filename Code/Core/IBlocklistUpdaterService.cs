namespace BlocklistUpdater.Core
{
    public interface IBlocklistUpdaterService
    {
        void Update();
        TargetApplicationCollection TargetApplications { get; }
        BlocklistCollection Blocklists { get; }
        IListManager ListManager { get; set; }
    }
}