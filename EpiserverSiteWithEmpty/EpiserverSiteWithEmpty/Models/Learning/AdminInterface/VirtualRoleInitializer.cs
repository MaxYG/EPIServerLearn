using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Security;
using EPiServer.ServiceLocation;

namespace EpiserverSiteWithEmpty.Models.Learning.AdminInterface
{
    /*[InitializableModule]
    [ModuleDependency((typeof(EPiServer.Web.InitializationModule)))]
    public class VirtualRoleInitializer : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            //IVirtualRoleRepository
            var virtualRoleRepository = VirtualRoleRepository<VirtualRoleProviderBase>.GetDefault();
            ServiceLocator.Current..TryGetExistingInstance<VirtualRoleRepository<T>>(out instance);
            virtualRoleRepository.Register("MyVirtualRoleType", new MyVirtualRoleType());
        }

        public void Uninitialize(InitializationEngine context) { }
        public void Preload(string[] parameters) { }
    }*/
}