using System;
using System.Collections.Generic;

namespace VRChatApiWrapper.WorldApi
{
    public class InstanceInfo
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<InstanceUserInfo> Private { get; set; }

        public List<InstanceUserInfo> Friends { get; set; }

        public List<InstanceUserInfo> Users { get; set; }

        public string Hidden { get; set; }

        public string Nonce { get; set; }
    }
}