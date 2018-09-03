
using VRChatApiWrapper.WorldApi;

namespace VRChatUtilModule.Models
{
    public class WorldSearchOption
    {
        public string Keyword { get; set; }

        public EndpointType EndpointType { get; set; }

        public SortOptions SortOptions { get; set; }

        public bool? IsFeatured { get; set; } = null;

        public bool NoOption => string.IsNullOrEmpty(this.Keyword) && 
                                this.EndpointType == EndpointType.Any && 
                                this.SortOptions == SortOptions.Popularity && 
                                this.IsFeatured != null;
    }
}
