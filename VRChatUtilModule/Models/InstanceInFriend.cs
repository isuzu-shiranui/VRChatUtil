using System.Collections.Generic;
using System.Linq;
using VRChatApiWrapper;
using VRChatApiWrapper.WorldApi;

namespace VRChatUtilModule.Models
{
    public class InstanceInFriend
    {
        public string WorldName { get; set; }
        
        public List<FriendData> Friends { get; set; }

        public static List<InstanceInFriend> GetInstanceInFriends(List<FriendData> friends)
        {
            return friends
                .GroupBy(x => new { x.InstanceId, x.StatusText })
                .Select(x => new InstanceInFriend
                {
                    WorldName = x.First().StatusText,
                    Friends = x.Select(y => y).ToList()
                })
                .ToList();
        }
    }
}