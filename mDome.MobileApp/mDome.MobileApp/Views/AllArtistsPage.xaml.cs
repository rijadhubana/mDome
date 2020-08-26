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
    public partial class AllArtistsPage : ContentPage
    {
        public AllArtistsPage(int genreId)
        {
            InitializeComponent();
            BindingContext = vm = new AllArtistsViewModel();
            vm.ThisGenreId = genreId;
            vm.InitCommand.Execute(null);
        }
        AllArtistsViewModel vm;

        private async void VisitArtist(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ArtistPage(vm.SelectedArtist.ArtistId));
        }
    }
}