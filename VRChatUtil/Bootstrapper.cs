using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using VRChatUtil.Views;
using System.Windows;

namespace VRChatUtil
{
    internal class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell() => this.Container.Resolve<MainWindow>();

        protected override void InitializeShell() => Application.Current.MainWindow?.Show();

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = this.ModuleCatalog as ModuleCatalog;
            moduleCatalog?.AddModule(typeof(VRChatUtilModule.VRChatUtilModule));
        }
    }
}