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
    public partial class AlbumPage : ContentPage
    {
        public AlbumPage(int albumId)
        {
            InitializeComponent();
            BindingContext = vm = new AlbumViewModel();
            vm.AlbumId = albumId;
            vm.InitCommand.Execute(null);
        }
        AlbumViewModel vm;

        private async void VisitTrack(object sender, EventArgs e)
        {
            StackLayout stack = sender as StackLayout;
            Label labelWithId = stack.Children[0] as Label;
            string abc = labelWithId.Text;
            await Navigation.PushAsync(new TrackPage(int.Parse(abc)));
        }

        private async void VisitArtist(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ArtistPage(vm.LoadedArtist.ArtistId));
        }

        private async void ReviewThisAlbum(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewReviewPage(vm.AlbumId));
        }

        private async void RelatedReviews(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RelatedReviewsPage(vm.AlbumId, null, null));
        }
    }
}