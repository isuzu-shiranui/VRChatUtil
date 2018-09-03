using Microsoft.Practices.Unity;
using Prism.Mvvm;
using VRChatUtilModule.Models;
using VRChatUtilModule.Services;
using VRChatUtilModule.Utility;

namespace VRChatUtilModule.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        private CultureType cultureType;

        public SettingsViewModel()
        {
            this.CultureType = (CultureType)Properties.Settings.Default.CultureType;
            ResourceService.Instance.ChangeLangage(this.CultureType.GetLocaleId());
        }

        /// <summary>
        /// 言語設定
        /// </summary>
        public CultureType CultureType
        {
            get => this.cultureType;
            set
            {
                this.SetProperty(ref this.cultureType, value);
                ResourceService.Instance.ChangeLangage(this.CultureType.GetLocaleId());

                Properties.Settings.Default.CultureType = (int) this.CultureType;
                Properties.Settings.Default.Save();
            }
        }
    }
}