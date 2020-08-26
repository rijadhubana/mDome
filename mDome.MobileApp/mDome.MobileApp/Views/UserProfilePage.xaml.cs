using mDome.MobileApp.ViewModels;
using mDome.Model;
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
    public partial class UserProfilePage : ContentPage
    {
        public UserProfilePage(int userId)
        {
            InitializeComponent();
            BindingContext = vm = new UserProfileViewModel();
            vm.UserId = userId;
            vm.InitCommand.Execute(null);
        }
        UserProfileViewModel vm = null;

        private async void RelatedPosts(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RelatedPostsPage(null,vm.UserId));
        }

        private async void EditProfile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(true));
        }

        private async void VisitArtist1(object sender, EventArgs e)
        {
            if (vm.Artist1.ArtistId != 0)
                await Navigation.PushAsync(new ArtistPage(vm.Artist1.ArtistId));
        }
        private async void VisitArtist2(object sender, EventArgs e)
        {
            if (vm.Artist2.ArtistId != 0)
                await Navigation.PushAsync(new ArtistPage(vm.Artist2.ArtistId));
        }
        private async void VisitArtist3(object sender, EventArgs e)
        {
            if (vm.Artist3.ArtistId != 0)
                await Navigation.PushAsync(new ArtistPage(vm.Artist3.ArtistId));
        }
        private async void VisitAlbum1(object sender, EventArgs e)
        {
            if (vm.Album1.AlbumId != 0)
                await Navigation.PushAsync(new AlbumPage(vm.Album1.AlbumId));
        }
        private async void VisitAlbum2(object sender, EventArgs e)
        {
            if (vm.Album2.AlbumId != 0)
                await Navigation.PushAsync(new AlbumPage(vm.Album2.AlbumId));
        }
        private async void VisitAlbum3(object sender, EventArgs e)
        {
            if (vm.Album3.AlbumId != 0)
                await Navigation.PushAsync(new AlbumPage(vm.Album3.AlbumId));
        }

        private async void RelatedReviews(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RelatedReviewsPage(null, vm.UserId, null));
        }

        private async void FeaturedTracklists(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FeaturedTracklistsPage(vm.UserId));
        }

        private async void FeaturedAlbumLists(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FeaturedAlbumListsPage(vm.UserId));
        }
    }
}