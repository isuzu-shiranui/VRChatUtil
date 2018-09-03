using System;

namespace VRChatUtilModule.Models
{
    [Serializable]
    public class LoginInfo
    {
        public string ID { get; set; }

        public string Password { get; set; }

        public bool RegisterLoginData { get; set; }
    }
}
