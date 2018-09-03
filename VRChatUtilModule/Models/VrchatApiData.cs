using VRChatApiWrapper;
using VRChatApiWrapper.UserApi;

namespace VRChatUtilModule.Models
{
    public class VrchatApiData
    {
        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        public static VrchatApiData Instance { get; } = new VrchatApiData();

        public UserInfo UserData { get; set; }

        public VrchatApiWrapper Wrapper { get; set; }
    }
}
