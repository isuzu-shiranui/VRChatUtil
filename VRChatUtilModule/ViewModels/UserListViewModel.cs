using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using VRChatApiWrapper.UserApi;
using VRChatUtilModule.Models;

namespace VRChatUtilModule.ViewModels
{
    public class UserListViewModel : BindableBase, INavigationAware
    {
        private List<OtherUserInfo> userList;
        private bool isDataDownload;

        public UserListViewModel()
        {
            this.SearchCommand = new DelegateCommand<string>(async param =>
            {
                var otherUserInfos = await VrchatApiData.Instance.Wrapper.AnyUser.GetUserListAsync(userName:param);
                this.UserList = otherUserInfos.Select(x => new OtherUserInfo
                {
                    Id = x.Id,
                    CurrentAvatarImageUrl = x.CurrentAvatarImageUrl,
                    CurrentAvatarThumbnailImageUrl = x.CurrentAvatarThumbnailImageUrl,
                    DeveloperType = x.DeveloperType,
                    DisplayName = x.DisplayName,
                    InstanceId = x.InstanceId,
                    Location = x.Location,
                    Tags = x.Tags,
                    UserName = x.UserName,
                    WorldId = x.WorldId
                }).ToList();
            });

            this.SendFriendRequestCommand = new DelegateCommand<string>(async param =>
            {
                var response = await VrchatApiData.Instance.Wrapper.Notification.SendFriendRequestAsync(param);
            });
        }

        public List<OtherUserInfo> UserList
        {
            get => this.userList;
            set => this.SetProperty(ref this.userList, value);
        }

        /// <summary>
        /// ダウンロード中か
        /// </summary>
        public bool IsDataDownload
        {
            get => this.isDataDownload;
            set => this.SetProperty(ref this.isDataDownload, value);
        }


        public DelegateCommand<string> SearchCommand { get; }

        public DelegateCommand<string> SendFriendRequestCommand { get; }

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
            
        }
    }
}