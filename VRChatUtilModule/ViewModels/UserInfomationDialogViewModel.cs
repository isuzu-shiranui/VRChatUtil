using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using VRChatApiWrapper.UserApi;
using VRChatUtilModule.Dialogs;

namespace VRChatUtilModule.ViewModels
{
    public class UserInfomationDialogViewModel : BindableBase, IInteractionRequestAware
    {
        private UserInfomationDialog notification;

        public UserInfomationDialogViewModel()
        {

        }

        public INotification Notification
        {
            get => this.notification;
            set => this.SetProperty(ref this.notification, value as UserInfomationDialog);
        }

        public Action FinishInteraction { get; set; }

        public UserInfo UserData { get; set; }
    }
}
