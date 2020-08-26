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
    public partial class FeaturedAlbumListsPage : ContentPage
    {
        public FeaturedAlbumListsPage(int userId)
        {
            InitializeComponent();
            BindingContext = vm = new FeaturedAlbumListsViewModel();
            vm.UserId = userId;
            vm.InitCommand.Execute(null);
        }
        FeaturedAlbumListsViewModel vm;
        private async void VisitAlbumList(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new AlbumListPage(vm.SelectedAlbumList.AlbumListId));
        }
    }
}