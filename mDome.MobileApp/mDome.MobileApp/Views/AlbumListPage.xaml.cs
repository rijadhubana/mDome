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
    public partial class AlbumListPage : ContentPage
    {
        public AlbumListPage(int albumListId)
        {
            InitializeComponent();
            BindingContext = vm = new AlbumListViewModel();
            vm.ThisAlbumListId = albumListId;
            vm.InitCommand.Execute(null);
        }
        AlbumListViewModel vm;

        private async void VisitAlbum(object sender, EventArgs e)
        {
            StackLayout stack = sender as StackLayout;
            Label labelWithId = stack.Children[0] as Label;
            string abc = labelWithId.Text;
            await Navigation.PushAsync(new AlbumPage(int.Parse(abc)));
        }

        private async void AddAlbums(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddOrRemoveAlbumsPage(vm.ThisAlbumListId, true));
        }

        private async void RemoveAlbums(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddOrRemoveAlbumsPage(vm.ThisAlbumListId, false));
        }
    }
}