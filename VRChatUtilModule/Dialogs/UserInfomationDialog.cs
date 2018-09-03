using Prism.Interactivity.InteractionRequest;
using VRChatApiWrapper.UserApi;

namespace VRChatUtilModule.Dialogs
{
    public class UserInfomationDialog : Confirmation
    {
        public UserInfo UserData { get; set; }
    }
}
