using mDome.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mDome.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenrePage : ContentPage
    {
        public GenrePage(int genreId)
        {
            InitializeComponent();
            BindingContext = vm = new GenreViewModel();
            vm.ThisGenreId = genreId;
            vm.InitCommand.Execute(null);
        }
        GenreViewModel vm;

        private async void VisitArtist(object sender, EventArgs e)
        {
            StackLayout stack = sender as StackLayout;
            Label labelWithId = stack.Children[0] as Label;
            string abc = labelWithId.Text;
            await Navigation.PushAsync(new ArtistPage(int.Parse(abc)));
        }

        private async void VisitTrack(object sender, EventArgs e)
        {
            StackLayout stack = sender as StackLayout;
            Label labelWithId = stack.Children[0] as Label;
            string abc = labelWithId.Text;
            await Navigation.PushAsync(new TrackPage(int.Parse(abc)));
        }

        private async void VisitAllTracks(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllTracksPage(null, vm.ThisGenreId));
        }

        private async void VisitAllArtists(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllArtistsPage(vm.ThisGenreId));
        }
    }
}