using System;
using System.Collections.Generic;

namespace VRChatApiWrapper.UserApi
{
    /// <summary>
    /// This contains most of the details of the user
    /// ユーザー情報
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// The user id
        /// ユーザーID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// the username (used for login)
        /// ログイン用ユーザー名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// the display name
        /// 表示名
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// the past display names
        /// 過去の表示名リスト
        /// </summary>
        public List<string> PastDisplayNames { get; set; }

        /// <summary>
        /// has an email
        /// メールがセットされているか
        /// </summary>
        public bool HasEmail { get; set; }

        /// <summary>
        /// has email pending for verification
        /// メール認証待ちか
        /// </summary>
        public bool HasPendingEmail { get; set; }

        /// <summary>
        /// the email with most of the user obfuscated
        /// 難読化加工済みメールアドレス
        /// </summary>
        public string ObfuscatedEmail { get; set; }

        /// <summary>
        /// the email pending for verification obfuscated
        /// 認証待ちの難読化加工済みメールアドレス
        /// </summary>
        public string ObfuscatedPendingEmail { get; set; }

        /// <summary>
        /// is the email verified
        /// メールが認証されているか
        /// </summary>
        public bool IsEmailVerified { get; set; }

        /// <summary>
        /// has birthday set
        /// 誕生日がセットされているか
        /// </summary>
        public bool HasBirthday { get; set; }

        /// <summary>
        /// unknown
        /// わからん
        /// </summary>
        public bool IsUnsubscribe { get; set; }

        /// <summary>
        /// IDs of the players you are friend with
        /// フレンドのID一覧
        /// </summary>
        public List<string> Friends { get; set; }

        /// <summary>
        /// unknown (possibly way to group friends together in the future)
        /// いつか...ね？
        /// </summary>
        public string FriendGroupName { get; set; }

        /// <summary>
        /// unknown (possibly legacy stuff)
        /// これは過去の遺産だ
        /// </summary>
        //public string Blueprints { get; set; }

        /// <summary>
        /// unknown (possibly legacy stuff)
        /// これも過去の遺産だ
        /// </summary>
        //public string CurrentAvatarBlueprint { get; set; }

        /// <summary>
        /// current user avatar ID
        /// アバターID
        /// </summary>
        public string CurrentAvatar { get; set; }

        /// <summary>
        /// URL to the avatar image
        /// アバター画像のURL
        /// </summary>
        public string CurrentAvatarImageUrl { get; set; }

        /// <summary>
        /// URL to the avatar thumbnail image (lower res)
        /// アバターのサムネイル画像のURL
        /// </summary>
        public string CurrentAvatarThumbnailImageUrl { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public string StatusDescription { get; set; }

        /// <summary>
        /// last accepted TOS version, used to check if needs to re-accept
        /// </summary>
        // ReSharper disable once InconsistentNaming
        public int AcceptedTOSVersion { get; set; }

        /// <summary>
        /// If the user is a steam user this is his steam details
        /// スチームのユーザーの場合、情報はここに
        /// </summary>
        public SteamDetails SteamDetails { get; set; }

        /// <summary>
        /// logged from the client
        /// クライアントからログインしているか
        /// </summary>
        public bool HasLoggedFromClient { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public string HomeLocation { get; set; }

        /// <summary>
        /// the user tags
        /// ユーザータグ
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// the user type
        /// ユーザー種別
        /// </summary>
        public DeveloperType DeveloperType { get; set; }
    }
}