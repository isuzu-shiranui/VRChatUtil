using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VRChatApiWrapper;
using VRChatApiWrapper.UserApi;
using VRChatUtilModule.Utility;

namespace VRChatUtilModule.Models
{
    [Serializable]
    public class FriendData
    {
        #region Properties
        public string Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string ImageUrl { get; set; }

        public string StatusText { get; set; }

        public string InstanceOccupant { get; set; }

        public List<string> FriendsWith { get; set; } = new List<string>();

        public HashSet<string> Tags { get; set; } = new HashSet<string>();

        public string WorldId => this.Location.Contains(':') ? this.Location.Split(':')[0] : string.Empty;

        public string InstanceId => this.Location.Contains(':') ? this.Location.Split(':')[1] : string.Empty;

        public string InstanceNumber => this.Location.Contains(':') ? $"#{this.Location.Split(':')[1].Split('~')[0]}" : string.Empty;

        #endregion

        #region Methods

        public async Task<List<FriendData>> GetFriendsAsync(VrchatApiWrapper wrapper)
        {
            var users = new List<FriendData>();
            var onlineList = await GetFriendsAsync(wrapper, false);
            var offlineList = await GetFriendsAsync(wrapper, true);
            users.AddRange(onlineList);
            users.AddRange(offlineList);
            return users;
        }

        private static async Task<List<FriendData>> GetFriendsAsync(VrchatApiWrapper wrapper, bool isOffline)
        {
            var users = new List<FriendData>();
            var offset = 0;
            for (; ; )
            {
                List<OtherUserInfo> friends;
                try
                {
                    var list = await wrapper.Friends.GetFriendsAsync(offset, 20, isOffline);
                    friends = list.Select(x => new OtherUserInfo
                    {
                        Id = x.Id,
                        CurrentAvatarImageUrl = x.CurrentAvatarImageUrl,
                        CurrentAvatarThumbnailImageUrl = x.CurrentAvatarThumbnailImageUrl,
                        DeveloperType = x.DeveloperType,
                        DisplayName = x.DisplayName,
                        InstanceId = x.InstanceId,
                        Location = x.Location,
                        Tags = x.Tags,
                        UserName = x.UserName,
                        WorldId = x.WorldId
                    }).ToList();
                }
                catch (Exception)
                {
                    friends = null;
                }

                if (friends == null) continue;
                foreach (var userBriefResponse in friends)
                {
                    var user = new FriendData
                    {
                        Id = userBriefResponse.Id,
                        Name = userBriefResponse.DisplayName,
                        Location = userBriefResponse.Location,
                        ImageUrl = userBriefResponse.CurrentAvatarThumbnailImageUrl
                    };
                    await ConvertLocationAsync(wrapper, user);
                    users.Add(user);
                }

                if (friends.Count < 20)
                {
                    break;
                }

                offset += friends.Count;
            }

            return users;
        }

        private static async Task ConvertLocationAsync(VrchatApiWrapper wrapper, FriendData user)
        {
            var worldData = new WorldData();
            var location = user.Location;
            var userId = user.Id;
            user.InstanceOccupant = "";
            switch (location)
            {
                case "offline":
                    user.StatusText = "Offline";
                    break;
                case "private":
                    user.StatusText = "Private";
                    break;
                default:
                    if (location.Contains(':'))
                    {
                        var array = location.Split(':');
                        if (array.GetElementOrDefault(1) == userId)
                        {
                            user.StatusText = "Private";
                        }
                        else
                        {
                            var worldResponse = await worldData.GetWorldAsync(wrapper, array.GetElementOrDefault(0));
                            if(worldResponse != null)
                            {
                                var worldInstanceResponse = await worldData.GetInstanceAsync(wrapper, array.GetElementOrDefault(0), array.GetElementOrDefault(1));
                                if (worldInstanceResponse?.Users != null)
                                {
                                    user.StatusText = worldResponse.Name;
                                }
                            }
                        }
                    }

                    break;
            }
        }

        #endregion
    }
}
