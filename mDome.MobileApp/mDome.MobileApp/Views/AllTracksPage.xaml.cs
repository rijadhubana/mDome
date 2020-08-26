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
    public partial class AllTracksPage : ContentPage
    {
        public AllTracksPage(int? artistId,int? genreId)
        {
            InitializeComponent();
            BindingContext = vm = new AllTracksViewModel();
            vm.ThisArtistId = artistId;
            vm.ThisGenreId = genreId;
            vm.InitCommand.Execute(null);
        }
        AllTracksViewModel vm;

        private async void VisitTrack(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new TrackPage(vm.SelectedTrack.TrackId));
        }
    }
}