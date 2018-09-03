using System;
using System.Collections.ObjectModel;
using System.Linq;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Prism.Regions;
using VRChatUtilModule.Dialogs;
using VRChatUtilModule.Models;
using VRChatUtilModule.Models.IO;

namespace VRChatUtilModule.ViewModels
{
    public class UserSelectDialogViewModel : BindableBase, IInteractionRequestAware
    {
        private const string SavePath = "2D2992C79C3C4FCFB2B11B30F8A47210";

        private ObservableCollection<FriendData> friends = new ObservableCollection<FriendData>();

        private UserSelectDialog notification;

        public UserSelectDialogViewModel()
        {
            this.AddContanctCommand = new DelegateCommand<FriendData>(param =>
            {
                ((UserSelectDialog) this.Notification).FriendData = param;

                this.FinishInteraction();
            });

            this.SearchCommand = new DelegateCommand<string>(param =>
            {
                var friendData = this.Friends.Where(x => x.Name.ToLower().Contains(param.ToLower())).ToList();
                this.Friends = new ObservableCollection<FriendData>(friendData);
                this.RaisePropertyChanged(nameof(this.Friends));
            });
        }

        public ObservableCollection<FriendData> Friends
        {
            get => this.friends;
            set => this.SetProperty(ref this.friends, value);
        }

        public INotification Notification
        {
            get => this.notification;
            set
            {
                this.SetProperty(ref this.notification, value as UserSelectDialog);
                this.Friends = BinarySerializer.LoadFromBinaryFile<ObservableCollection<FriendData>>(SavePath);
                this.RaisePropertyChanged(nameof(this.Friends));
            }
        }

        public Action FinishInteraction { get; set; }

        public DelegateCommand<FriendData> AddContanctCommand { get; }

        public DelegateCommand<string> SearchCommand { get; }

    }
}