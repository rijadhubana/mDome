using mDome.MobileApp.Helper;
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
    public partial class PopupAlbums : Rg.Plugins.Popup.Pages.PopupPage
    {
        private readonly APIService _albumService = new APIService("Album");
        public PopupAlbums()
        {
            InitializeComponent();
            BindingContext = model = new PopupAlbumsViewModel();
        }
        public Model.Album _selectedAlbum;
        public event EventHandler<object> CallbackEvent;
        private PopupAlbumsViewModel model = null;
        protected override void OnDisappearing() => CallbackEvent?.Invoke(this, _selectedAlbum);

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedAlbum = await _albumService.GetById<Model.Album>(model.selectedAlbum.AlbumId);
            await PopupNavigation.Instance.PopAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            _selectedAlbum = new Model.Album { AlbumId = 0, AlbumName = "Not Selected" };
            await PopupNavigation.Instance.PopAsync();
        }
    }
}