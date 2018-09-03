using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using VRChatUtilModule.Models;
using VRChatUtilModule.Models.IO;
using VRChatUtilModule.Utility;

namespace VRChatUtilModule.ViewModels
{
    public class InstanceInFriendsViewModel : BindableBase, INavigationAware
    {

        private const string SavePath = "2D2992C79C3C4FCFB2B11B30F8A47210";

        /// <summary>
        /// インスタンスごとのフレンドリスト
        /// </summary>
        private ObservableCollection<InstanceInFriend> friends = new ObservableCollection<InstanceInFriend>();

        public InstanceInFriendsViewModel()
        {
            this.ChangeViewCommand = new DelegateCommand(() =>
            {
                this.RegionManager?.RequestNavigate("ContentRegion", "InstanceInFriendsView");
            });

            this.JoinCommand = new DelegateCommand<InstanceInFriend>(param =>
            {
                Process.Start($"vrchat://launch?id={param.Friends.First().WorldId}&instanceId={param.Friends.First().InstanceId}");
            });
        }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        /// <summary>
        /// インスタンスごとのフレンドリスト
        /// </summary>
        public ObservableCollection<InstanceInFriend> Friends
        {
            get => this.friends;
            set => this.SetProperty(ref this.friends, value);
        }

        public DelegateCommand ChangeViewCommand { get; }

        public DelegateCommand<InstanceInFriend> JoinCommand { get; }

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
            try
            {
                var list = BinarySerializer.LoadFromBinaryFile<ObservableCollection<FriendData>>(SavePath).ToList();
                this.GetFriendsData(list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void GetFriendsData(List<FriendData> friendData)
        {
          
            var instanceInFriends = InstanceInFriend.GetInstanceInFriends(friendData);
            instanceInFriends = instanceInFriends.OrderBy(x => x.WorldName).ToLast(x => x.WorldName == "Private").ToLast(x => x.WorldName == "Offline").ToList();

            this.Friends = new ObservableCollection<InstanceInFriend>(instanceInFriends);

        }
    }
}