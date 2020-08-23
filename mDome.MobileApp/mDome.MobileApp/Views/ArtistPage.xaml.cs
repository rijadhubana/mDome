using mDome.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mDome.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistPage : ContentPage
    {
        public ArtistPage(int artistId)
        {
            InitializeComponent();
            BindingContext = vm = new ArtistViewModel();
            vm.ArtistId = artistId;
            vm.InitCommand.Execute(null);
        }
        ArtistViewModel vm;

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

        private async void VisitTrack(object sender, EventArgs e)
        {
            StackLayout stack = sender as StackLayout;
            Label labelWithId = stack.Children[0] as Label;
            string abc = labelWithId.Text;
            await Navigation.PushAsync(new TrackPage(int.Parse(abc)));
        }

        private async void AllAlbumsPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllAlbumsPage(vm.ArtistId));
        }

        private async void AllTracksPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllTracksPage(vm.ArtistId));
        }

        private async void VisitReviews(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RelatedReviewsPage(null, null, vm.ArtistId));
        }

        private async void VisitPosts(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RelatedPostsPage(vm.ArtistId, null));
        }
    }
}