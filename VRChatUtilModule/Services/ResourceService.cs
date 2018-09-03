using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace VRChatUtilModule.Services
{
    /// <summary>
    /// 多言語化されたリソースと、言語の切り替え機能を提供します。
    /// </summary>
    public class ResourceService : INotifyPropertyChanged
    {
        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        public static ResourceService Instance { get; } = new ResourceService();

        /// <summary>
        /// 多言語化されたリソースを取得します。
        /// </summary>
        public Properties.Resources Resources { get; } = new Properties.Resources();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// 指定されたカルチャ名を使用して、リソースのカルチャを変更します。
        /// </summary>
        /// <param name="name">カルチャの名前。</param>
        public void ChangeLangage(string name)
        {
            Properties.Resources.Culture = CultureInfo.GetCultureInfo(name);
            this.RaisePropertyChanged("Resources");
        }
    }
}
