using System.Windows;
using Prism.Interactivity.InteractionRequest;
using Prism.Regions;
using VRChatUtilModule.Dialogs;
using VRChatUtilModule.Models;

namespace VRChatUtilModule.ViewModels
{
    public class LoginShellViewModel : INavigationAware
    {
        private readonly IRegionManager regionManager;

        public LoginShellViewModel(IRegionManager regionManager) => this.regionManager = regionManager;

        public InteractionRequest<LoginDialog> LoginRequest { get; } = new InteractionRequest<LoginDialog>();

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
            this.LoginRequest.Raise(new LoginDialog
            {
                Title = "Login",
            }, result =>
            {

                if (result.UserData != null)
                {
                    VrchatApiData.Instance.UserData = result.UserData;

                    this.regionManager.RequestNavigate("ContentRegion", "FriendsListView");
                    return;
                }

                Application.Current.Shutdown();

            });
        }
    }
}
