using System.Collections.Generic;

namespace VRChatApiWrapper.UserApi
{
    public class OtherUserInfo
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string CurrentAvatarImageUrl { get; set; }

        public string CurrentAvatarThumbnailImageUrl { get; set; }

        public List<string> Tags { get; set; }

        public DeveloperType DeveloperType { get; set; }

        public string Location { get; set; }

        public string WorldId { get; set; }

        public string InstanceId { get; set; }
    }
}