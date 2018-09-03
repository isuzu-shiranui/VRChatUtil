using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Globalization;
using VRChatUtilModule.Dialogs;
using VRChatUtilModule.Models;
using VRChatUtilModule.Models.IO;
using Microsoft.Practices.Unity;
using Prism.Commands;
using VRChatUtilModule.Properties;
using System.Diagnostics;

namespace VRChatUtilModule.ViewModels
{
    public class FriendsListViewModel : BindableBase, INavigationAware
    {
        private const string SavePath = "2D2992C79C3C4FCFB2B11B30F8A47210";

        /// <summary>
        /// 詳細表示モード
        /// </summary>
        private bool isDetailDisplayMode;

        /// <summary>
        /// フレンドリスト
        /// </summary>
        private ObservableCollection<FriendData> friends = new ObservableCollection<FriendData>();

        /// <summary>
        /// ダウンロード中か
        /// </summary>
        private bool isDataDownload;

        public FriendsListViewModel()
        {
            this.ChangeViewCommand = new DelegateCommand(() =>
            {
                this.RegionManager?.RequestNavigate("ContentRegion", "InstanceInFriendsView");
            });

            this.JoinCommand = new DelegateCommand<FriendData>(param =>
            {
                Process.Start($"vrchat://launch?id={param.WorldId}&instanceId={param.InstanceId}");
            });

            //var a = Resources.ResourceManager.GetString(nameof(Resources.Account_Display_Name), CultureInfo.CurrentCulture);
        }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        /// <summary>
        /// 詳細表示モード
        /// </summary>
        public bool IsDetailDisplayMode
        {
            get => this.isDetailDisplayMode;
            set => this.SetProperty(ref this.isDetailDisplayMode, value);
        }

        /// <summary>
        /// ダウンロード中か
        /// </summary>
        public bool IsDataDownload
        {
            get => this.isDataDownload;
            set => this.SetProperty(ref this.isDataDownload, value);
        }

        public DelegateCommand ChangeViewCommand { get; }

        public DelegateCommand<FriendData> JoinCommand { get; }

        public InteractionRequest<UserInfomationDialog> UserInfomationRequest { get; } = new InteractionRequest<UserInfomationDialog>();

        public ObservableCollection<FriendData> Friends
        {
            get => this.friends;
            set => this.SetProperty(ref this.friends, value);
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
            this.GetFrieldsDataAsync();
        }

        private async void GetFrieldsDataAsync()
        {
            this.IsDataDownload = true;

            var friendData = new FriendData();

            var friends = await friendData.GetFriendsAsync(VrchatApiData.Instance.Wrapper);
            

            this.Friends = new ObservableCollection<FriendData>(friends);

            BinarySerializer.SaveToBinaryFile(this.Friends, SavePath);

            this.IsDataDownload = false;

        }
    }
}
