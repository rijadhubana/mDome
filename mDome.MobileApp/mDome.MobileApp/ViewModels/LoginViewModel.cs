using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using mDome.MobileApp.Views;
using mDome.Model.Requests;
using System.Linq;

namespace mDome.MobileApp.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private readonly APIService _userService = new APIService("UserProfile");
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            RegisterCommand = new Command(Register);
        }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        private void SetAPIServiceNull()
        {
            APIService.Username = "";
            APIService.Password = "";
            APIService.loggedProfile = null;
        }
        async Task Login()
        {
            try
            {
                IsBusy = true;
                APIService.Username = Username;
                APIService.Password = Password;
                var result = await _userService.Get<List<Model.UserProfile>>(new UserProfileSearchRequest() { Username = APIService.Username });
                APIService.loggedProfile = result.First();
                if (APIService.loggedProfile.SuspendedFlag==true)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Your account has been suspended. Please contact " +
                        "the administrator for further details", "OK");
                    SetAPIServiceNull();
                    IsBusy = false;
                    return;
                }
                Application.Current.MainPage = new MasterPage(new NavigationPage(new NewsFeedPage()));
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Wrong username or password", "OK");
                SetAPIServiceNull();
                IsBusy = false;
                return;
            }
        }
        private void Register()
        {
            bool editProfile = false;
            Application.Current.MainPage = new RegisterPage(editProfile);
        }
    }
}
