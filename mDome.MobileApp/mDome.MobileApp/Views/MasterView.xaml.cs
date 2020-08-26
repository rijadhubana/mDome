using mDome.MobileApp.ViewModels;
using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mDome.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterView : ContentPage
    {
        public MasterView()
        {
            InitializeComponent();
            BindingContext = vm = new MasterViewModel();
        }
        MasterViewModel vm  = null;
        public event EventHandler<object> masterViewEventHandler;
        //private void MenuItemTapped(object sender, EventArgs e)
        //{
        //    //if (vm.SelectedMenuItem == "News Feed")
        //    //    Application.Current.MainPage = new MasterPage(new NavigationPage(new NewsFeedPage()));
        //    //else if (vm.SelectedMenuItem == "My Profile")
        //    //    Application.Current.MainPage = new MasterPage(new NavigationPage(new UserProfilePage(APIService.loggedProfile.UserId)));
        //    //else if (vm.SelectedMenuItem== "Followers/Following")
        //    //    Application.Current.MainPage = new MasterPage(new NavigationPage(new FollowersFollowingPage()));
        //    //else if (vm.SelectedMenuItem=="Notifications")
        //    //    Application.Current.MainPage = new MasterPage(new NavigationPage(new NotificationListPage()));
        //    //else if (vm.SelectedMenuItem == "Search")
        //    //    Application.Current.MainPage = new MasterPage(new NavigationPage(new SearchPage()));
        //    //else if (vm.SelectedMenuItem == "My Playlists/Album Lists")
        //    //     Application.Current.MainPage= new MasterPage(new NavigationPage(new MyTracklistsAlbumlistsPage()));
        //    //else if (vm.SelectedMenuItem == "History")
        //    //{
        //    //    APIService _tracklistService = new APIService("Tracklist");
        //    //    var history = await _tracklistService.Get<List<Tracklist>>(new TracklistSearchRequest()
        //    //    {
        //    //        UserId = APIService.loggedProfile.UserId,
        //    //        TracklistName = "History"
        //    //    });
        //    //    if (history.Count!=0)
        //    //        Application.Current.MainPage = new MasterPage(new NavigationPage(new TracklistPage(history.First().TracklistId)));
        //    //}
        //    //else if(vm.SelectedMenuItem== "Report a Problem")
        //    //    Application.Current.MainPage = new MasterPage(new NavigationPage(new ReportAProblemPage()));
        //    //else if (vm.SelectedMenuItem == "Logout")
        //    //{
        //    //    APIService.loggedProfile = null;
        //    //    APIService.Username = "";
        //    //    APIService.Password = "";
        //    //    Application.Current.MainPage = new LoginPage();
        //    //}
        //    //vm.SelectedMenuItem = "";
        //}

        private void MenuItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            masterViewEventHandler?.Invoke(this, vm.SelectedMenuItem);
        }
        public void SetPropertySelected()
        {
            vm.SelectedMenuItem = "";
        }
    }
}