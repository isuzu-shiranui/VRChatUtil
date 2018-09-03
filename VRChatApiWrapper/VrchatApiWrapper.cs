using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using VRChatApiWrapper.NotificationApi;
using VRChatApiWrapper.UserApi;
using VRChatApiWrapper.WorldApi;

namespace VRChatApiWrapper
{
    public class VrchatApiWrapper
    {
        public static string ApiKey = "JlE5Jldo5Jibnk5O5hTx6XVqsJu4WJ26";

        public static HttpClient HttpClient;

        public VrchatApiWrapper(string userName, string password)
        {
            if (HttpClient == null)
            {
                HttpClient = new HttpClient
                {
                    BaseAddress = new Uri("https://api.vrchat.cloud/api/1/")
                };
            }

            var authEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{userName}:{password}"));

            var header = HttpClient.DefaultRequestHeaders;
            if (header.Contains("Authorization"))
            {
                header.Remove("Authorization");
            }

            header.Add("Authorization", $"Basic {authEncoded}");
        }

        public CurrentUser CurrentUser { get; } = new CurrentUser();

        public Friends Friends { get; } = new Friends();

        public AnyUser AnyUser { get; } = new AnyUser();

        public World World { get; } = new World();

        public Notification Notification { get; } = new Notification();

        public RemoteConfig RemoteConfig { get; } = new RemoteConfig();
    }
}
