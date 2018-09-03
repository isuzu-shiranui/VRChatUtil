using System;
using System.Windows.Controls;

namespace VRChatUtilModule.Views
{
    /// <inheritdoc cref="UserControl" />
    /// <summary>
    /// WorldListView.xaml の相互作用ロジック
    /// </summary>
    public partial class WorldListView
    {
        public WorldListView() => this.InitializeComponent();

        public event EventHandler ScrollEnd;

        protected virtual void OnScrollEnd(EventArgs e)
        {
            this.ScrollEnd?.Invoke(this, e);
        }

        private void WorldList_OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.VerticalOffset + e.ViewportHeight >= e.ExtentHeight)
            {
                this.OnScrollEnd(new EventArgs());
            }
        }
    }
}
