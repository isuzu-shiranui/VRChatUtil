using Prism.Mvvm;
using System.Threading.Tasks;
using VRChatApiWrapper;
using VRChatApiWrapper.UserApi;
using VRChatUtilModule.Models.IO;

namespace VRChatUtilModule.Models
{
    public class Login : BindableBase
    {
        public const string SavePath = "ccdf5bf31ecf45bca0e9c76d399a7a61";

        public Task<UserInfo> LoginAsync(LoginInfo loginInfo)
        {
            if (loginInfo.RegisterLoginData)
            {
                BinarySerializer.SaveToBinaryFile(loginInfo, SavePath);

                Properties.Settings.Default.RegisterLoginData = true;
                Properties.Settings.Default.Save();

                return LoginAsync(loginInfo.ID, loginInfo.Password);
            }

            Properties.Settings.Default.RegisterLoginData = false;
            Properties.Settings.Default.Save();

            return LoginAsync(loginInfo.ID, loginInfo.Password);
        }

        private static async Task<UserInfo> LoginAsync(string id, string password)
        {
            var wrapper = new VrchatApiWrapper(id, password);

            await wrapper.RemoteConfig.GetRemoteConfigAsync();

            var userResponse = await wrapper.CurrentUser.LoginAsync();

            if (userResponse == null) return null;


            VrchatApiData.Instance.Wrapper = wrapper;
            return userResponse;

        }
    }
}
