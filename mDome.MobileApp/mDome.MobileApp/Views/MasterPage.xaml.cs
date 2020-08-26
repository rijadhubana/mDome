using mDome.MobileApp.ViewModels;
using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mDome.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        MasterView mvPage = new MasterView();
        public MasterPage(NavigationPage nav)
        {
            InitializeComponent();
            nav.BarBackgroundColor = Color.Black;
            Detail = nav;
            Master = mvPage;
            IsPresented = false;
            mvPage.masterViewEventHandler += async (object sender, object e) =>
            {
                string menuItem = (string)e;
                await MenuNavigate(menuItem);
                mvPage.SetPropertySelected();
            };

        }
        public async Task MenuNavigate(string menuItem)
        {
            if (menuItem == "News Feed")
                ExecNavigation(new NavigationPage(new NewsFeedPage()));
            else if (menuItem == "My Profile")
                ExecNavigation(new NavigationPage(new UserProfilePage(APIService.loggedProfile.UserId)));
            else if (menuItem == "Followers/Following")
                ExecNavigation(new NavigationPage(new FollowersFollowingPage()));
            else if (menuItem == "Notifications")
                ExecNavigation(new NavigationPage(new NotificationListPage()));
            else if (menuItem == "Search")
                ExecNavigation(new NavigationPage(new SearchPage()));
            else if (menuItem == "My Tracklists/Album Lists")
                ExecNavigation(new NavigationPage(new MyTracklistsAlbumlistsPage()));
            else if (menuItem == "Report a Problem")
                ExecNavigation(new NavigationPage(new ReportAProblemPage()));
            else if (menuItem=="History")
            {
                APIService _tracklistService = new APIService("Tracklist");
                var history = await _tracklistService.Get<List<Tracklist>>(new TracklistSearchRequest()
                {
                    UserId = APIService.loggedProfile.UserId,
                    TracklistName = "History"
                });
                if (history.Count != 0)
                    ExecNavigation(new NavigationPage(new TracklistPage(history.First().TracklistId)));
            }
            else if (menuItem=="Logout")
            {
                APIService.loggedProfile = null;
                APIService.Username = "";
                APIService.Password = "";
                Application.Current.MainPage = new LoginPage();
            }
        }
        private void ExecNavigation(NavigationPage nav)
        {
            nav.BarBackgroundColor = Color.Black;
            Detail = nav;
            IsPresented = false;
        }
    }
}