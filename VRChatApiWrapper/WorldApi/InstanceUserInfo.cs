using System;
using System.Collections.Generic;
using VRChatApiWrapper.UserApi;

namespace VRChatApiWrapper.WorldApi
{
    public class InstanceUserInfo
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string CurrentAvatarImageUrl { get; set; }
        public string CurrentAvatarThumbnailImageUrl { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public DeveloperType DeveloperType { get; set; }
        public string Status { get; set; }
        public string StatusDescription { get; set; }
        public string NetworkSessionId { get; set; }
    }
}