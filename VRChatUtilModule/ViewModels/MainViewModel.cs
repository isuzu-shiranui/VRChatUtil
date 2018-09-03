using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace VRChatUtilModule.ViewModels
{
    public class MainViewModel : BindableBase, INavigationAware
    {
        public MainViewModel()
        {
            this.NavigationCommand = new DelegateCommand<string>(param =>
            {
                this.RegionManager.RequestNavigate("ContentRegion", param);
            });
        }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public DelegateCommand<string> NavigationCommand { get; }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <inheritdoc />
        /// <summary>
        /// /遷移前
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// 遷移後
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegionManager?.RequestNavigate("ContentRegion", "LoginShellView");

        }
    }
}