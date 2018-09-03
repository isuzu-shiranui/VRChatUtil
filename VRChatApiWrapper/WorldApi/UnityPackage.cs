using System;
using Newtonsoft.Json;

namespace VRChatApiWrapper.WorldApi
{
    public class UnityPackage
    {
        ///<summary>
        ///The unity package id
        ///</summary>
        public string Id { get; set; }

        ///<summary>
        ///url with the assets used in the world
        ///</summary>
        public string AssetUrl { get; set; }

        ///<summary>
        ///url to the plugin
        ///</summary>
        public string PluginUrl { get; set; }

        ///<summary>
        ///Version of unity the package was created with
        ///</summary>
        public string UnityVersion { get; set; }

        ///<summary>
        ///Unity version formatted into a number (?)
        ///</summary>
        public int UnitySortNumber { get; set; }

        ///<summary>
        ///Version of that asset
        ///</summary>
        public int AssetVersion { get; set; }

        ///<summary>
        ///For what platform
        ///</summary>
        public string Platform { get; set; }

        ///<summary>
        ///the date the world was created at
        ///</summary>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

    }
}