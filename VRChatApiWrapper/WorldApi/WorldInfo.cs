using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VRChatApiWrapper.WorldApi
{
    public class WorldInfo
    {
        ///<summary>
        /// World ID
        ///</summary>
        public string Id { get; set; }

        ///<summary>
        /// World Name
        ///</summary>
        public string Name { get; set; }

        ///<summary>
        /// World description
        ///</summary>
        public string Description { get; set; }

        ///<summary>
        /// Is the world featured
        ///</summary>
        public bool Featured { get; set; }

        ///<summary>
        /// The user ID of the creator
        ///</summary>
        public string AuthorId { get; set; }

        ///<summary>
        /// The name of the creator
        ///</summary>
        public string AuthorName { get; set; }

        ///<summary>
        /// How many likes this world has
        ///</summary>
        public int TotalLikes { get; set; }

        ///<summary>
        /// How many visits this world has
        ///</summary>
        public int TotalVisits { get; set; }

        ///<summary>
        /// The maximum amount of people in an instance
        ///</summary>
        public short Capacity { get; set; }

        ///<summary>
        /// World tags
        ///</summary>
        public List<string> Tags { get; set; }

        ///<summary>
        /// The status of the world
        ///</summary>
        public ReleaseStatus ReleaseStatus { get; set; }

        ///<summary>
        /// URL to the image of the world
        ///</summary>
        public string ImageUrl { get; set; }

        ///<summary>
        /// URL to the image of the world (small)
        ///</summary>
        public string ThumbnailImageUrl { get; set; }

        ///<summary>
        /// URL for downloading the map as unity3d compressed file
        ///</summary>
        public string AssetUrl { get; set; }

        ///<summary>
        /// URL (usually DLL). This is probably used for custom scripts
        ///</summary>
        public string PluginUrl { get; set; }

        ///<summary>
        /// URL for downloading unitypackage file (only avariable to the map's editor)
        ///</summary>
        public string UnityPackageUrl { get; set; }

        ///<summary>
        /// unknown
        ///</summary>
        public string Namespacae { get; set; }

        ///<summary>
        /// unknown
        ///</summary>
        public bool UnityPackageUpdated => false;

        ///<summary>
        /// Versions of this world
        ///</summary>
        public List<UnityPackage> UnityPackages { get; set; }

        ///<summary>
        /// unknown (probably password?)
        ///</summary>
        public bool IsSecure { get; set; }

        ///<summary>
        /// unknown (probably makes the world to be locked)
        ///</summary>
        public bool IsLockdown { get; set; }

        ///<summary>
        /// World version
        ///</summary>
        public int Version { get; set; }

        ///<summary>
        /// unknown
        ///</summary>
        public string Organization { get; set; }

        ///<summary>
        /// The instances of this world
        ///</summary>
        [JsonIgnore]
        public List<WorldInstance> Instances { get; set; }

        [JsonProperty("instances")]
        public List<List<object>> InstancesFromJson { get; set; }

        ///<summary>
        /// Total amount of people in this world
        ///</summary>
        public int Occupants { get; set; }

    }
}