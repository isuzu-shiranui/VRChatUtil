using System;
using System.Collections.Generic;

namespace VRChatApiWrapper
{
    public class Config
    {
        ///<summary>
        ///Unknown
        ///</summary>
        public string MessageOfTheDay { get; set; }

        ///<summary>
        ///The ID of the world you get kicked into for timeout
        ///</summary>
        public string TimeOutWorldId { get; set; }

        ///<summary>
        ///unknown
        ///</summary>
        public string GearDemoRoomId { get; set; }

        ///<summary>
        ///release server version
        ///</summary>
        public string ReleaseServerVersionStandalone { get; set; }

        ///<summary>
        ///Where you would originally download the game
        ///</summary>
        public string DownloadLinkWindows { get; set; }

        ///<summary>
        ///Game version of release
        ///</summary>
        public string ReleaseAppVersionStandalone { get; set; }

        ///<summary>
        ///Game version of dev
        ///</summary>
        public string DevAppVersionStandalone { get; set; }

        ///<summary>
        ///dev server version
        ///</summary>
        public string DevServerVersionStandalone { get; set; }

        ///<summary>
        ///the developer download link (Useless)
        ///</summary>
        public string DevDownloadLinkWindows { get; set; }

        ///<summary>
        ///Current TOS version that ues needs to accept
        ///</summary>
        public int CurrentTosVersion { get; set; }

        ///<summary>
        ///SDK Unitypackage for release
        ///</summary>
        public string ReleaseSdkUrl { get; set; }

        ///<summary>
        ///SDK Version for release
        ///</summary>
        public string ReleaseSdkVersion { get; set; }

        ///<summary>
        ///SDK Unitypackage for release
        ///</summary>
        public string DevSdkUrl { get; set; }

        ///<summary>
        ///SDK Version for release
        ///</summary>
        public string DevSdkVersion { get; set; }

        ///<summary>
        ///from where the client is allowed to download assets
        ///</summary>
        public List<string> WhiteListedAssetUrls { get; set; }

        ///<summary>
        ///The Key for using the API
        ///</summary>
        public string ClientApiKey { get; set; }

        ///<summary>
        ///Before VRChat had support for vive you would have to download this in order for it too work
        ///</summary>
        public string ViveWindowsUrl { get; set; }

        ///<summary>
        ///Unity version of the SDK
        ///</summary>
        public string SdkUnityVersion { get; set; }

        ///<summary>
        ///The ID of the hub world
        ///</summary>
        public string HubWorldId { get; set; }

        ///<summary>
        ///Default Starting World
        ///</summary>
        public string HomeWorldId { get; set; }

        ///<summary>
        ///The world for when you first install vrchat / does not matter if new user
        ///</summary>
        public string TutorialWorldId { get; set; }

        ///<summary>
        ///will the client send a bunch of anonymous data about your device / world / etc
        ///</summary>
        public bool DisableEventStream { get; set; }

        ///<summary>
        ///if set to true everyone can upload avatars  otherwise only users with special permission can
        ///</summary>
        public bool DisableAvatarGating { get; set; }

        ///<summary>
        ///if set to true everyone can give feedback  otherwise only users with special permission can
        ///</summary>
        public bool DisableFeedbackGating { get; set; }

        ///<summary>
        ///unknown  seems to be comma separeted list of strings
        ///</summary>
        public string Plugin { get; set; }

        ///<summary>
        ///when you aren't able to upload avatars or worlds on the sdk  this message appears (only on newer sdk)
        ///</summary>
        public string SdkNotAllowedToPublishMessage { get; set; }

        ///<summary>
        ///Their faq for the sdk
        ///</summary>
        public string SdkDeveloperFaqUrl { get; set; }

        ///<summary>
        ///their official vrchat discord
        ///</summary>
        public string SdkDiscordUrl { get; set; }

        ///<summary>
        ///when you try to choose avatar from private worlds this message apears
        ///</summary>
        public string NotAllowedToSelectAvatarInPrivateWorldMessage { get; set; }

        ///<summary>
        ///timeout for verification (TODO: what kind of verification)  assumed in seconds
        ///</summary>
        public int UserVerificationTimeout { get; set; }

        ///<summary>
        ///timeout between updating  assuming seconds
        ///</summary>
        public int UserUpdatePeriod { get; set; }

        ///<summary>
        ///delay between verifications  assuming seconds
        ///</summary>
        public int UserVerificationDelay { get; set; }

        ///<summary>
        ///unknown
        ///</summary>
        public int UserVerificationRetry { get; set; }

        ///<summary>
        ///unknown
        ///</summary>
        public int WorldUpdatePeriod { get; set; }

        ///<summary>
        ///unknown
        ///</summary>
        public int ModerationQueryPeriod { get; set; }

        ///<summary>
        ///Probably VRChat's office address
        ///</summary>
        public string Address { get; set; }

        ///<summary>
        ///VRChat team's contact email
        ///</summary>
        public string ContactEmail { get; set; }

        ///<summary>
        ///VRChat team's support email
        ///</summary>
        public string SupportEmail { get; set; }

        ///<summary>
        ///VRChat team's job positions related email
        ///</summary>
        public string JobsEmail { get; set; }

        ///<summary>
        ///VRChat team's copyright issues related email
        ///</summary>
        public string CopyrightEmail { get; set; }

        ///<summary>
        ///VRChat team's moderation related email
        ///</summary>
        public string ModerationEmail { get; set; }

        ///<summary>
        ///App name (VrChat)
        ///</summary>
        public string AppName { get; set; }

        ///<summary>
        ///the current in use server API
        ///</summary>
        public string ServerName { get; set; }

        ///<summary>
        ///unknown
        ///</summary>
        public string DeploymentGroup { get; set; }

        ///<summary>
        ///current api version
        ///</summary>
        public string BuildVersionTag { get; set; }

        ///<summary>
        ///The API key  seems to be the same as clientApiKey
        ///</summary>
        public string ApiKey { get; set; }


    }
}