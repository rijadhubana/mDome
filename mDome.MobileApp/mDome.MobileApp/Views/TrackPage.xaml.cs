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
    public partial class TrackPage : ContentPage
    {
        public TrackPage(int trackId)
        {
            InitializeComponent();
            BindingContext = vm = new TrackViewModel();
            vm.TrackId = trackId;
            vm.InitCommand.Execute(null);
        }
        TrackViewModel vm;

        private async void VisitArtist(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ArtistPage(vm.ThisArtist.ArtistId));
        }

        private async void VisitAlbum(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlbumPage(vm.ThisAlbum.AlbumId));

        }
    }
}