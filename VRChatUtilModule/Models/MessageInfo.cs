using System;
using VRChatApiWrapper.NotificationApi;
using VRChatApiWrapper.UserApi;

namespace VRChatUtilModule.Models
{
    [Serializable]
    public class MessageInfo
    {
        public OtherUserInfo UserInfo { get; set; }

        public NotificationInfo NotificationInfo { get; set; }
    }
}