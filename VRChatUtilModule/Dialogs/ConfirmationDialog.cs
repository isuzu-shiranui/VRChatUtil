using Prism.Interactivity.InteractionRequest;

namespace VRChatUtilModule.Dialogs
{
    public class ConfirmationDialog : Confirmation
    {
        public string Message { get; set; }

        public ConfirmationType ConfirmationType { get; set; }
    }

    public enum ConfirmationType
    {
        AbortRetryIgnore,
        Ok,
        OkCancel,
        RetryCancel,
        YesNo,
        YesNoCancel
    }
}