using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using Prism.Interactivity.InteractionRequest;
using VRChatApiWrapper;
using VRChatApiWrapper.WorldApi;
using VRChatUtilModule.Dialogs;
using VRChatUtilModule.Models;

namespace VRChatUtilModule.ViewModels
{
    public class WorldListViewModel : BindableBase, INavigationAware
    {
        private readonly WorldData worldData = new WorldData();

        /// <summary>
        /// 詳細表示モード
        /// </summary>
        private bool isDetailDisplayMode;

        /// <summary>
        /// ワールド検索オプション
        /// </summary>
        private WorldSearchOption worldSearchOption = new WorldSearchOption();

        /// <summary>
        /// ワールド一覧
        /// </summary>
        private ObservableCollection<WorldInfo> worlds;

        /// <summary>
        /// ダウンロード中か
        /// </summary>
        private bool isDataDownload;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public WorldListViewModel()
        {
            this.SearchCommand = new DelegateCommand(this.SearchWordAsync);

            this.DetailPopupCommand = new DelegateCommand<WorldInfo>(async param =>
            {
                this.InteractionRequest.Raise(new WorldDetailDialog
                {
                    Title = param.Name,
                    WoroldInfo = await this.worldData.GetWorldAsync(VrchatApiData.Instance.Wrapper, param.Id)
                });
            });
        }

        /// <summary>
        /// ダウンロード中か
        /// </summary>
        public bool IsDataDownload
        {
            get => this.isDataDownload;
            set => this.SetProperty(ref this.isDataDownload, value);
        }

        /// <summary>
        /// 詳細表示モード
        /// </summary>
        public bool IsDetailDisplayMode
        {
            get => this.isDetailDisplayMode;
            set => this.SetProperty(ref this.isDetailDisplayMode, value);
        }

        /// <summary>
        /// ワールド検索オプション
        /// </summary>
        public WorldSearchOption WorldSearchOption
        {
            get => this.worldSearchOption;
            set => this.SetProperty(ref this.worldSearchOption, value);
        }

        /// <summary>
        /// ワールド一覧
        /// </summary>
        public ObservableCollection<WorldInfo> Worlds
        {
            get => this.worlds;
            set => this.SetProperty(ref this.worlds, value);
        }

        /// <summary>
        /// 検索コマンド
        /// </summary>
        public DelegateCommand SearchCommand { get; }

        /// <summary>
        /// 詳細表示コマンド
        /// </summary>
        public DelegateCommand<WorldInfo> DetailPopupCommand { get; }

        public InteractionRequest<WorldDetailDialog> InteractionRequest { get; } = new InteractionRequest<WorldDetailDialog>();

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <inheritdoc />
        /// <summary>
        /// /遷移前
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// 遷移後
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.GetWorldsAsync();
        }

        /// <summary>
        /// ワールド一覧取得
        /// </summary>
        private async void GetWorldsAsync()
        {
            this.IsDataDownload = true;

            this.Worlds = new ObservableCollection<WorldInfo>(await this.worldData.SearchWorldAsync(VrchatApiData.Instance.Wrapper));

            this.IsDataDownload = false;
        }

        /// <summary>
        /// オプションを利用してワールドを検索
        /// </summary>
        private async void SearchWordAsync()
        {
            this.IsDataDownload = true;

            this.Worlds = new ObservableCollection<WorldInfo>(await this.worldData.SearchWorldAsync(VrchatApiData.Instance.Wrapper, this.WorldSearchOption));

            this.IsDataDownload = false;
        }
    }
}
