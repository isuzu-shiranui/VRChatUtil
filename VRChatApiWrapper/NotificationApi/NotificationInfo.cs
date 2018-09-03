using System;
using Newtonsoft.Json;

namespace VRChatApiWrapper.NotificationApi
{
    /// <summary>
    /// 通知情報
    /// </summary>
    public class NotificationInfo
    {
        /// <summary>
        /// 通知ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 送信者ユーザーID
        /// </summary>
        public string SenderUserId { get; set; }

        /// <summary>
        /// 送信者名
        /// </summary>
        public string SenderUserName { get; set; }

        /// <summary>
        /// 受信者ユーザーID
        /// </summary>
        public string ReceiverUserId { get; set; }

        /// <summary>
        /// 通知種別
        /// </summary>
        public NotificationType NotificationType { get; set; }

        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public object Details { get; set; }

        /// <summary>
        /// 既読
        /// </summary>
        [JsonProperty("seen")]
        public bool IsSeen { get; set; }

        /// <summary>
        /// 送信日時
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}