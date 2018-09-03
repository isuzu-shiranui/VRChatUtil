using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace VRChatApiWrapper.UserApi
{
    public class Friends
    {
        public async Task<List<OtherUserInfo>> GetFriendsAsync(int offset = 0, int count = 20, bool offline = false)
        {
            var response = await VrchatApiWrapper.HttpClient.GetAsync($"auth/user/friends?apiKey={VrchatApiWrapper.ApiKey}&offset={offset}&n={count}&offline={offline.ToString().ToLowerInvariant()}");

            List<OtherUserInfo> result = null;

            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<List<OtherUserInfo>>();
            }

            return result;
        }
    }
}