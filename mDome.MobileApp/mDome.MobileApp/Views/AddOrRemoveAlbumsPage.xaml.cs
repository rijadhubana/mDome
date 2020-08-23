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
    public partial class AddOrRemoveAlbumsPage : ContentPage
    {
        public AddOrRemoveAlbumsPage(int albumListId,bool addAlbums)
        {
            InitializeComponent();
            BindingContext = vm = new AddOrRemoveAlbumsViewModel();
            vm.AlbumListId = albumListId;
            vm.AddAlbums = addAlbums;
            vm.InitCommand.Execute(null);
        }
        AddOrRemoveAlbumsViewModel vm;

        private void ClickedEvent(object sender, SelectedItemChangedEventArgs e)
        {
            vm.ClickedCommand.Execute(null);
        }
    }
}