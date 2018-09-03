using System;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using VRChatUtilModule.Dialogs;

namespace VRChatUtilModule.ViewModels
{
    public class ConfirmationDialogViewModel : BindableBase, IInteractionRequestAware
    {
        private ConfirmationDialog notification;

        public INotification Notification
        {
            get => this.notification;
            set => this.SetProperty(ref this.notification, value as ConfirmationDialog);
        }

        public Action FinishInteraction { get; set; }
    }
}