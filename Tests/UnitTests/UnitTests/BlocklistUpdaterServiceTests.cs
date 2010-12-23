using BlocklistUpdater.Core;
using BlocklistUpdater.Core.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BlocklistUpdater.Tests.UnitTests
{
    [TestClass]
    public class BlocklistUpdaterServiceTests
    {
        private IBlocklistUpdaterService service;
        private Mock<IListManager> manager;

        [TestInitialize]
        public void Initialize()
        {
            manager = new Mock<IListManager>();
            service = new BlocklistUpdaterService(manager.Object);
        }

        [TestMethod]
        public void Requires_at_least_one_target_application()
        {
            string exceptionMessage = null;
            
            try
            {
                service.Update();
            }
            catch (UpdateException ue)
            {
                exceptionMessage = ue.Message;
            }
            
            Assert.AreEqual( Resources.NoTargetApplicationsException, exceptionMessage );
        }

        [TestMethod]
        public void Holds_an_empty_collection_of_blocklists_by_default()
        {
            Assert.IsNotNull(service.Blocklists);
            Assert.AreEqual(0, service.Blocklists.Count);
        }

        [TestMethod]
        public void Holds_an_empty_collection_of_target_applications_by_default()
        {
            Assert.IsNotNull(service.TargetApplications);
            Assert.AreEqual(0, service.TargetApplications.Count);
        }

        [TestMethod]
        public void Ctor_creates_a_default_list_manager()
        {
            Assert.IsNotNull(service.ListManager);
        }

        [TestMethod]
        public void Update_calls_list_manager_to_get_latest_list()
        {
            service.TargetApplications.Add( new Mock<ITargetApplication>().Object );
            
            service.Update();

            manager.Verify(listManager => listManager.GetLatestVersionOf(service.Blocklists), Times.Once());
        }
    }
}