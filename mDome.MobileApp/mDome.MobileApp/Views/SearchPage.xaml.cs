using BottomBar.XamarinForms;
using mDome.MobileApp.ViewModels;
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
    public partial class SearchPage : BottomBarPage
    {
        public SearchPage()
        {
            InitializeComponent();
            BindingContext = vm = new SearchPageViewModel();
            vm.AccessTracklistEventHandler += (object s, object r) =>
            {
                if (vm.accessTracklistNumber == 0)
                    Application.Current.MainPage.DisplayAlert("Error", "Tracklist not found.", "OK");
                else Navigation.PushAsync(new TracklistPage(vm.accessTracklistNumber));
            };
            vm.AccessAlbumListEventHandler += (object s, object r) =>
            {
                if (vm.accessAlbumListNumber == 0)
                    Application.Current.MainPage.DisplayAlert("Error", "Tracklist not found.", "OK");
                else Navigation.PushAsync(new AlbumListPage(vm.accessAlbumListNumber));
            };
            
        }
        SearchPageViewModel vm;
        private async void VisitArtist(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ArtistPage(vm.SelectedArtist.ArtistId));
        }

        private async void VisitAlbum(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new AlbumPage(vm.SelectedAlbum.AlbumId));
        }

        private async void VisitTrack(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new TrackPage(vm.SelectedTrack.TrackId));
        }

        private async void VisitTracklist(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new TracklistPage(vm.SelectedTracklist.TracklistId));
        }

        private async void VisitAlbumList(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new AlbumListPage(vm.SelectedAlbumList.AlbumListId));
        }

        private async void VisitUser(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new UserProfilePage(vm.SelectedUser.UserId));
        }

        private async void VisitGenre(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new GenrePage(vm.SelectedGenre.GenreId));
        }
    }
}