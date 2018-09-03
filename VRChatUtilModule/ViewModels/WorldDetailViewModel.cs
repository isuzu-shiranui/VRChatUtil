using System;
using System.Diagnostics;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using VRChatApiWrapper.WorldApi;
using VRChatUtilModule.Dialogs;
using VRChatUtilModule.Models;

namespace VRChatUtilModule.ViewModels
{
    public class WorldDetailViewModel : BindableBase, IInteractionRequestAware
    {
        private WorldDetailDialog notification;
        private WorldInfo worldInfo;

        public WorldDetailViewModel()
        {
            this.LaunchPublicCommand = new DelegateCommand(() =>
            {
                Process.Start($"vrchat://launch?id={this.WorldInfo.Id}:6289~public({VrchatApiData.Instance.UserData.Id})");
            });

            this.LaunchFriendPlusCommand = new DelegateCommand(() =>
            {
                Process.Start($"vrchat://launch?id={this.WorldInfo.Id}:6289~hidden({VrchatApiData.Instance.UserData.Id})");
            });

            this.LaunchFriendCommand = new DelegateCommand(() =>
            {
                Process.Start($"vrchat://launch?id={this.WorldInfo.Id}:6289~friends({VrchatApiData.Instance.UserData.Id})");
            });

            this.LaunchInvitePlusCommand = new DelegateCommand(() =>
            {
                Process.Start($"vrchat://launch?id={this.WorldInfo.Id}:6289~private({VrchatApiData.Instance.UserData.Id})~canRequestInvite()");

            });

            this.LaunchInviteCommand = new DelegateCommand(() =>
            {
                Process.Start($"vrchat://launch?id={this.WorldInfo.Id}:6289~private({VrchatApiData.Instance.UserData.Id})");
            });
        }


        public INotification Notification
        {
            get => this.notification;
            set
            {
                this.SetProperty(ref this.notification, value as WorldDetailDialog);
                this.WorldInfo = this.notification.WoroldInfo;
                this.RaisePropertyChanged(nameof(this.WorldInfo));
            }
        }

        public Action FinishInteraction { get; set; }

        public DelegateCommand LaunchPublicCommand { get; }
        public DelegateCommand LaunchFriendPlusCommand { get; }
        public DelegateCommand LaunchFriendCommand { get; }
        public DelegateCommand LaunchInvitePlusCommand { get; }
        public DelegateCommand LaunchInviteCommand { get; }


        public WorldInfo WorldInfo
        {
            get => this.worldInfo;
            set
            {
                if(this.notification == null) return;
                this.SetProperty(ref this.worldInfo, value);
            }
        }
    }
}