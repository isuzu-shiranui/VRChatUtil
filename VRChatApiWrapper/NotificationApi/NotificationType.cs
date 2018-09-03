namespace VRChatApiWrapper.NotificationApi
{
    /// <summary>
    /// 通知種別
    /// </summary>
    public enum NotificationType
    {
        /// <summary>
        /// すべて
        /// </summary>
        All,

        /// <summary>
        /// メッセージ
        /// </summary>
        Message,

        /// <summary>
        /// フレンドリクエスト
        /// </summary>
        FriendRequest,

        /// <summary>
        /// 招待
        /// </summary>
        Invite,

        /// <summary>
        /// キック投票
        /// </summary>
        VoteToKick,

        /// <summary>
        /// ?
        /// </summary>
        Help,

        /// <summary>
        /// ?
        /// </summary>
        Hidden
    }
}