using MahApps.Metro.Controls;
using Prism.Interactivity;
using System.Windows;
using System.Windows.Media;

namespace VRChatUtilModule.Dialogs
{
    public class MetroPopupWindowAction : PopupWindowAction
    {
        protected override Window CreateWindow() => new MetroWindow
        {
            Style = new Style(),
            SizeToContent = SizeToContent.Manual,
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen,
            GlowBrush = Brushes.Black,
            BorderThickness = new Thickness(0),
        };
    }
}