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
    public partial class AllAlbumsPage : ContentPage
    {
        public AllAlbumsPage(int artistId)
        {
            InitializeComponent();
            BindingContext = vm = new AllAlbumsViewModel();
            vm.ThisArtistId=artistId;
            vm.InitCommand.Execute(null);
        }
        AllAlbumsViewModel vm;

        private async void VisitAlbum(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new AlbumPage(vm.SelectedAlbum.AlbumId));
        }
    }
}