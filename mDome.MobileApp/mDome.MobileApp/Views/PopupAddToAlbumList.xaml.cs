using mDome.MobileApp.ViewModels;
using Rg.Plugins.Popup.Services;
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
    public partial class PopupAddToAlbumList : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupAddToAlbumList(int albumId)
        {
            InitializeComponent();
            BindingContext = vm = new PopupAddToAlbumListViewModel();
            vm.ThisAlbumId = albumId;
            vm.InitCommand.Execute(null);
        }
        PopupAddToAlbumListViewModel vm;
        public int _selectedAlbumListId;
        public event EventHandler<object> CallbackEvent;
        protected override void OnDisappearing() => CallbackEvent?.Invoke(this, _selectedAlbumListId);
        private async void Button_Clicked(object sender, EventArgs e)
        {
            _selectedAlbumListId = 0;
            await PopupNavigation.Instance.PopAsync();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedAlbumListId = vm.SelectedAlbumList.AlbumListId;
            await PopupNavigation.Instance.PopAsync();
        }
    }
}