using Prism.Interactivity.InteractionRequest;
using VRChatApiWrapper.WorldApi;

namespace VRChatUtilModule.Dialogs
{
    public class WorldDetailDialog : Confirmation
    {
        public WorldInfo WoroldInfo { get; set; }
    }
}