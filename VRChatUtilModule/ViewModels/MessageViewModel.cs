using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using VRChatApiWrapper.UserApi;
using VRChatUtilModule.Dialogs;
using VRChatUtilModule.Models;
using VRChatUtilModule.Models.IO;
using static VRChatUtilModule.Utility.EnumerableExtension;

namespace VRChatUtilModule.ViewModels
{
    public class MessageViewModel : BindableBase, INavigationAware
    {
        private bool isDataDownload;
        private ObservableCollection<MessageInfo> messageList;
        private ObservableCollection<MessageInfo> messageHistoryList;
        private string currentUserId;

        private const string SavePath = "A6D44962BB98415581E3163704DC0BD8";

        public MessageViewModel()
        {
            //ユーザー選択
            this.NavigateChatCommand = new DelegateCommand<string>(param =>
            {
                var history = this.MessageList?
                    .Where(x => x.NotificationInfo?.SenderUserId == param || x.NotificationInfo?.ReceiverUserId == param)
                    .OrderBy(x => x.NotificationInfo.CreatedAt)
                    .ToList();

                if(history == null) return;

                this.MessageHistoryList = new ObservableCollection<MessageInfo>(history);

                this.CurrentUserId = param;
            });

            //メッセージ送信
            this.SendMessageCommand = new DelegateCommand<string>(async param =>
            {
                var notificationInfo = await VrchatApiData.Instance.Wrapper.Notification.SendMessageAsync(this.CurrentUserId, param);
                if (notificationInfo != null)
                {
                    var userData = VrchatApiData.Instance.UserData;
                    this.MessageList.Add(new MessageInfo
                    {
                        NotificationInfo = notificationInfo,
                        UserInfo = new OtherUserInfo
                        {
                            Id = userData.Id,
                            CurrentAvatarThumbnailImageUrl = userData.CurrentAvatarThumbnailImageUrl,
                            CurrentAvatarImageUrl = userData.CurrentAvatarImageUrl,
                            DeveloperType = userData.DeveloperType,
                            DisplayName = userData.DisplayName,
                            UserName = userData.UserName,
                            Tags = userData.Tags
                        }
                    });

                    BinarySerializer.SaveToBinaryFile(this.MessageList.Distinct(x => x.NotificationInfo.Id), SavePath);
                }
            });

            //ユーザー追加
            this.AddContactCommand = new DelegateCommand(() =>
            {
                this.InteractionRequest.Raise(new UserSelectDialog{Title = "Select user"}, r =>
                {
                    if(r.FriendData == null) return;

                    if(this.SenderUserList.Any(x => x.Id == r.FriendData.Id)) return;

                    this.MessageList.Add(new MessageInfo
                    {
                        UserInfo = new OtherUserInfo
                        { 
                            CurrentAvatarThumbnailImageUrl = r.FriendData.ImageUrl,
                            DisplayName = r.FriendData.Name,
                            Id = r.FriendData.Id,
                            UserName = r.FriendData.Name
                        }
                    });
                });

                BinarySerializer.SaveToBinaryFile(this.MessageList, SavePath);
                this.RaisePropertyChanged(nameof(this.MessageList));
                this.RaisePropertyChanged(nameof(this.SenderUserList));
            });
        }

        /// <summary>
        /// メッセージ情報リスト
        /// </summary>
        public ObservableCollection<MessageInfo> MessageList
        {
            get => this.messageList;
            set
            {
                this.SetProperty(ref this.messageList, value);
                this.RaisePropertyChanged(nameof(this.SenderUserList));
            }
        }

        /// <summary>
        /// 送信者リスト
        /// </summary>
        public ObservableCollection<OtherUserInfo> SenderUserList
        {
            get
            {
                var senders = this.messageList?.Select(x => x.UserInfo).Distinct(x => x.Id).ToList();
                return senders == null ? new ObservableCollection<OtherUserInfo>() : new ObservableCollection<OtherUserInfo>(senders);
            }
        }

        /// <summary>
        /// 指定された人との送受信履歴
        /// </summary>
        public ObservableCollection<MessageInfo> MessageHistoryList
        {
            get => this.messageHistoryList;
            set => this.SetProperty(ref this.messageHistoryList, value);
        }

        /// <summary>
        /// ダウンロード中か
        /// </summary>
        public bool IsDataDownload
        {
            get => this.isDataDownload;
            set => this.SetProperty(ref this.isDataDownload, value);
        }

        public string CurrentUserId
        {
            get => this.currentUserId;
            set => this.SetProperty(ref this.currentUserId, value);
        }

        public DelegateCommand<string> NavigateChatCommand { get; }

        public DelegateCommand<string> SendMessageCommand { get; }

        public DelegateCommand AddContactCommand { get; }

        public InteractionRequest<UserSelectDialog> InteractionRequest { get; } = new InteractionRequest<UserSelectDialog>();


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
            this.GetAllMEssagesAsync();
            this.RaisePropertyChanged(nameof(this.MessageList));
            this.RaisePropertyChanged(nameof(this.SenderUserList));
        }

        private async void GetAllMEssagesAsync()
        {
            this.IsDataDownload = true;

            try
            {
                var messages = await VrchatApiData.Instance.Wrapper.Notification.GetAllMessagesAsync();

                var messagesList = new ObservableCollection<MessageInfo>();

                foreach (var notificationInfo in messages)
                {
                    var result =
                        await VrchatApiData.Instance.Wrapper.AnyUser.GetByIdAsync(notificationInfo.SenderUserId);
                    messagesList.Add(new MessageInfo
                    {
                        NotificationInfo = notificationInfo,
                        UserInfo = new OtherUserInfo
                        {
                            Id = result.Id,
                            CurrentAvatarImageUrl = result.CurrentAvatarImageUrl,
                            CurrentAvatarThumbnailImageUrl = result.CurrentAvatarThumbnailImageUrl,
                            DeveloperType = result.DeveloperType,
                            DisplayName = result.DisplayName,
                            InstanceId = result.InstanceId,
                            Location = result.Location,
                            Tags = result.Tags,
                            UserName = result.UserName,
                            WorldId = result.WorldId
                        }
                    });
                }

                this.MessageList = messagesList;

                //var sendMessages = await VrchatApiData.Instance.Wrapper.Notification.GetAllMessagesAsync(isSent: true);

                //sendMessages.ForEach(notificationInfo =>
                //{
                //    messagesList.Add(new MessageInfo
                //    {
                //        NotificationInfo = notificationInfo,
                //        UserInfo = new OtherUserInfo
                //        {
                //            CurrentAvatarThumbnailImageUrl = VrchatApiData.Instance.UserData.CurrentAvatarThumbnailImageUrl
                //        }
                //    });

                //});

                //this.MessageList = messagesList;

                //var loadData = BinarySerializer.LoadFromBinaryFile<List<MessageInfo>>(SavePath);

                //if (loadData == null) return;

                //this.MessageList = new ObservableCollection<MessageInfo>(messagesList.Union(loadData).ToList());
            }
            catch (Exception)
            {
                // ignored
            }
            finally
            {
                this.IsDataDownload = false;
            }            
        }
    }
}