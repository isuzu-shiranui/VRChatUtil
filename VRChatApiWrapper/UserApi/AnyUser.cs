using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VRChatApiWrapper.UserApi
{
    public class AnyUser
    {
        /// <summary>
        /// IDでユーザーを取得
        /// </summary>
        /// <param name="id">検索対象ユーザーID</param>
        /// <returns></returns>
        public async Task<OtherUserInfo> GetByIdAsync(string id)
        {
            OtherUserInfo otherUserInfo = null;
            try
            {
                var response = await VrchatApiWrapper.HttpClient.GetAsync($"users/{id}?apiKey={VrchatApiWrapper.ApiKey}");

                if (!response.IsSuccessStatusCode) return null;

                otherUserInfo = await response.Content.ReadAsAsync<OtherUserInfo>();
            }
            catch (Exception)
            {
                // ignored
            }

            return otherUserInfo;
        }

        /// <summary>
        /// ユーザー一覧取得
        /// </summary>
        /// <param name="offset">オフセット</param>
        /// <param name="count">取得数(最大100)</param>
        /// <param name="isActiveOnry">アクティブのみか</param>
        /// <param name="userName">検索するユーザー名</param>
        /// <param name="developerType"></param>
        /// <returns></returns>
        public async Task<List<OtherUserInfo>> GetUserListAsync(int offset = 0, int count = 20, bool isActiveOnry = false,
            string userName = null, DeveloperType? developerType = null)
        {
            var builder = new StringBuilder();
            builder.Append($"&n={count}");
            builder.Append($"&offset={offset}");

            if (!string.IsNullOrEmpty(userName))
                builder.Append($"&search={userName}");
            if (developerType != null)
                builder.Append($"&developerType={developerType}");

            var baseUrl = isActiveOnry ? "users/active" : "users";

            var response = await VrchatApiWrapper.HttpClient.GetAsync($"{baseUrl}?apiKey={VrchatApiWrapper.ApiKey}{builder}");

            if (!response.IsSuccessStatusCode) return null;

            return await response.Content.ReadAsAsync<List<OtherUserInfo>>();
        }
    }
}