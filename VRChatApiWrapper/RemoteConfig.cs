using System.Net.Http;
using System.Threading.Tasks;

namespace VRChatApiWrapper
{
    public class RemoteConfig
    {
        public async Task<Config> GetRemoteConfigAsync()
        {
            var response = await VrchatApiWrapper.HttpClient.GetAsync("config");

            if (!response.IsSuccessStatusCode) return null;

            var responce = await response.Content.ReadAsAsync<Config>();

            VrchatApiWrapper.ApiKey = responce.ClientApiKey;

            return responce;
        }
    }
}