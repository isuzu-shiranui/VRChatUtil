using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using System.IO;
using VRChatUtilModule.Dialogs;
using VRChatUtilModule.Models;
using VRChatUtilModule.Models.IO;

namespace VRChatUtilModule.ViewModels
{
    public class LoginDialogViewModel : BindableBase, IInteractionRequestAware
    {

        private LoginDialog notification;
        private LoginInfo loginInfo = new LoginInfo();

        public LoginDialogViewModel()
        {
            this.LoginCommand = new DelegateCommand(async () =>
            {
                var login =  new Login();
                var userdata = await login.LoginAsync(this.LoginInfo);

                if (userdata == null) return;

                ((LoginDialog) this.Notification).UserData = userdata;

                this.FinishInteraction();
            });

            if(File.Exists(Login.SavePath))
                this.LoginInfo = BinarySerializer.LoadFromBinaryFile<LoginInfo>(Login.SavePath);

        }

        public INotification Notification
        {
            get => this.notification;
            set => this.SetProperty(ref this.notification, value as LoginDialog);
        }

        public Action FinishInteraction { get; set; }

        public LoginInfo LoginInfo
        {
            get => this.loginInfo;
            set => this.SetProperty(ref this.loginInfo, value);
        }

        /// <summary>
        /// ログインコマンド
        /// </summary>
        public DelegateCommand LoginCommand { get; }
    }
}
