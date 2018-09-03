using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using VRChatApiWrapper.WorldApi;

namespace VRChatApiWrapper.UserApi
{
    public class CurrentUser
    {
        public async Task<UserInfo> LoginAsync()
        {
            var response = await VrchatApiWrapper.HttpClient.GetAsync($"auth/user?apiKey={VrchatApiWrapper.ApiKey}");

            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserInfo>(json);
        }
    }
}