using Prism.Interactivity.InteractionRequest;
using VRChatApiWrapper.UserApi;

namespace VRChatUtilModule.Dialogs
{
    public class LoginDialog : Confirmation
    {
        public UserInfo UserData { get; set; }
    }
}
