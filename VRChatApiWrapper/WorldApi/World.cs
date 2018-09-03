using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace VRChatApiWrapper.WorldApi
{
    public class World
    {
        public async Task<WorldInfo> GetByIdAsync(string id)
        {
            var response = await VrchatApiWrapper.HttpClient.GetAsync($"worlds/{id}?apiKey={VrchatApiWrapper.ApiKey}");

            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadAsAsync<WorldInfo>();

                
            result.Instances = result.InstancesFromJson.Select(x => new WorldInstance
            {
                Id = (string)x.FirstOrDefault(),
                Count = int.TryParse(x.LastOrDefault()?.ToString(), out var resultInt) ? resultInt : 0
            }).ToList();

            return result;
        }

        public async Task<List<WorldInfo>> SearchAsync(EndpointType? endpointType = null, bool? featured = null,
            SortOptions? sort = null, UserOptions? user = null, int count = 20, int offset = 0, 
            string userId = null, string keyword = null, string tags = null, string excludeTags = null,
            ReleaseStatus? releaseStatus = null, string maxUnityVersion = null, string minUnityVersion = null,
            string maxAssetVersion = null, string minAssetVersion = null, string platform = null)
        {
            var builder = new StringBuilder();
            builder.Append($"&n={count}");
            builder.Append($"&offset={offset}");

            if (featured.HasValue)
            {
                builder.Append($"&featured={featured.Value}");

                if (featured.Value && sort.HasValue == false)
                {
                    builder.Append("&sort=order");
                }
            }

            if (sort.HasValue)
            {
                builder.Append($"&sort={sort.Value.ToString().ToLowerInvariant()}");

                if (sort.Value == SortOptions.Popularity && featured.HasValue == false)
                {
                    builder.Append("&featured=false");
                }
            }

            if (user.HasValue)
                builder.Append($"&user={user.Value.ToString().ToLowerInvariant()}");
            if (!string.IsNullOrEmpty(userId))
                builder.Append($"&userId={userId}");
            if (!string.IsNullOrEmpty(keyword))
                builder.Append($"&search={keyword}");
            if (!string.IsNullOrEmpty(tags))
                builder.Append($"&tag={tags}");
            if (!string.IsNullOrEmpty(excludeTags))
                builder.Append($"&notag={excludeTags}");
            if (releaseStatus.HasValue)
                builder.Append($"&releaseStatus={releaseStatus.Value.ToString().ToLowerInvariant()}");

            var baseUrl = "worlds";
            if (endpointType.HasValue)
            {
                switch (endpointType.Value)
                {
                    case EndpointType.Active:
                        baseUrl = "worlds/active";
                        break;
                    case EndpointType.RecentlyVisited:
                        baseUrl = "worlds/recent";
                        break;
                    case EndpointType.Favorite:
                        baseUrl = "worlds/favorites";
                        break;
                }
            }

            var response = await VrchatApiWrapper.HttpClient.GetAsync($"{baseUrl}?apiKey={VrchatApiWrapper.ApiKey}{builder}");

            List<WorldInfo> result = null;

            if (!response.IsSuccessStatusCode) return result;

            result = await response.Content.ReadAsAsync<List<WorldInfo>>();

            return result;
        }

        public async Task<InstanceInfo> GetInstanceInfoAsync(string worldId, string instanceId)
        {
            var response = await VrchatApiWrapper.HttpClient.GetAsync($"worlds/{worldId}/{instanceId}?apiKey={VrchatApiWrapper.ApiKey}");

            if (!response.IsSuccessStatusCode) return null;

            var text = await response.Content.ReadAsStringAsync();

            var json = JObject.Parse(text);

            var res = new InstanceInfo
            {
                Id = json["id"].ToString(),
                Private = json["private"] is JArray ? json["private"].Select(x => x.ToObject<InstanceUserInfo>()).ToList() : null,
                Friends = json["friends"] is JArray ? json["friends"].Select(x => x.ToObject<InstanceUserInfo>()).ToList() : null,
                Users = json["users"] is JArray ? json["users"].Select(x => x.ToObject<InstanceUserInfo>()).ToList() : null,
                Name = json["name"].ToString(),
                Hidden = json["hidden"] == null || json["hidden"].Type == JTokenType.Null ? null : json["hidden"].ToString(),
                Nonce = json["nonce"]?.ToString(),
            };

            return res;
        }
    }
}