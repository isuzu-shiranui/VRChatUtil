using Prism.Mvvm;
using Prism.Regions;
using VRChatApiWrapper.UserApi;
using VRChatUtilModule.Models;

namespace VRChatUtilModule.ViewModels
{
    public class AccountViewModel : BindableBase, INavigationAware
    {
        private UserInfo userData;
        private bool avatarAccess;
        private bool worldAccess;

        public UserInfo UserData
        {
            get => this.userData;
            set => this.SetProperty(ref this.userData, value);
        }

        public bool AvatarAccess
        {
            get => this.avatarAccess;
            set => this.SetProperty(ref this.avatarAccess, value);
        }

        public bool WorldAccess
        {
            get => this.worldAccess;
            set => this.SetProperty(ref this.worldAccess, value);
        }

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
            this.UserData = VrchatApiData.Instance.UserData;

            this.AvatarAccess = this.UserData.Tags.Contains("system_avatar_access");

            this.WorldAccess = this.UserData.Tags.Contains("system_world_access");

        }

    }
}