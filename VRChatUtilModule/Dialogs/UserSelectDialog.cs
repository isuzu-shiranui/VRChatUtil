using Prism.Interactivity.InteractionRequest;
using VRChatUtilModule.Models;

namespace VRChatUtilModule.Dialogs
{
    public class UserSelectDialog : Confirmation
    {
        public FriendData FriendData { get; set; }
    }
}