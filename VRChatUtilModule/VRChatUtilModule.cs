using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System.Linq;

namespace VRChatUtilModule
{
    /// <inheritdoc />
    public class VRChatUtilModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;

        public VRChatUtilModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            this.container.RegisterTypes(
                AllClasses.FromAssemblies(typeof(VRChatUtilModule).Assembly)
                .Where(x => x.Namespace != null && x.Namespace.EndsWith(".Models")),
                WithMappings.FromAllInterfacesInSameAssembly,
                getLifetimeManager: WithLifetime.ContainerControlled);

            this.container.RegisterTypes(
                AllClasses.FromAssemblies(typeof(VRChatUtilModule).Assembly)
                .Where(x => x.Namespace != null && x.Namespace.EndsWith(".Views")),
                _ => new[] { typeof(object) },
                WithName.TypeName);

            this.regionManager.RequestNavigate("FrameRegion", "MainView");
        }
    }
}