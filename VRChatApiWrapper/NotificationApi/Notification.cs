using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace VRChatApiWrapper.NotificationApi
{
    public class Notification
    {
        /// <summary>
        /// メッセージ取得
        /// </summary>
        /// <param name="notificationType">通知種別</param>
        /// <param name="isSent">自分が送信したもの</param>
        /// <param name="after">日付指定</param>
        /// <returns></returns>
        public async Task<List<NotificationInfo>> GetAllMessagesAsync(
            NotificationType? notificationType = null, bool? isSent = null, DateTime? after = null)
        {
            var builder = new StringBuilder();

            if(notificationType.HasValue)
                builder.Append($"&type={notificationType.ToString().ToLowerInvariant()}");
            if (isSent.HasValue)
                builder.Append($"&sent={isSent.Value.ToString().ToLowerInvariant()}");
            if (after.HasValue)
                builder.Append($"&after={after}");

            var response =
                await VrchatApiWrapper.HttpClient.GetAsync(
                    $"auth/user/notifications?apiKey={VrchatApiWrapper.ApiKey}{builder}");
            if (!response.IsSuccessStatusCode) return null;

            var a = response.Content.ReadAsStringAsync();

            return await response.Content.ReadAsAsync<List<NotificationInfo>>();
        }

        /// <summary>
        /// メッセージ送信
        /// </summary>
        /// <param name="userId">送信先ユーザーID</param>
        /// <param name="message">メッセージ</param>
        /// <returns></returns>
        public async Task<NotificationInfo> SendMessageAsync(string userId, string message)
        {
            var json = new JObject
            {
                ["type"] = "message",
                ["message"] = message
            };

            var content = new StringContent(json.ToString(), Encoding.UTF8);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await VrchatApiWrapper.HttpClient.PostAsync($"user/{userId}/notification?apiKey={VrchatApiWrapper.ApiKey}", content);

            if (!response.IsSuccessStatusCode) return null;

            var notificationInfo = await response.Content.ReadAsAsync<NotificationInfo>();

            return notificationInfo;
        }

        /// <summary>
        /// メッセージ送信
        /// </summary>
        /// <param name="userId">送信先ユーザーID</param>
        /// <returns></returns>
        public async Task<NotificationInfo> SendFriendRequestAsync(string userId)
        {
            var response = await VrchatApiWrapper.HttpClient.PostAsync($"user/{userId}/friendRequest?apiKey={VrchatApiWrapper.ApiKey}", null);

            if (!response.IsSuccessStatusCode) return null;

            var notificationInfo = await response.Content.ReadAsAsync<NotificationInfo>();

            return notificationInfo;
        }
    }
}