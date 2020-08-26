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
    public partial class PopupArtists : Rg.Plugins.Popup.Pages.PopupPage
    {
        private readonly APIService _artistService = new APIService("Artist");
        public PopupArtists()
        {
            InitializeComponent();
            BindingContext = model = new PopupArtistsViewModel();
        }
        public Model.Artist _selectedArtist;
        public event EventHandler<object> CallbackEvent;
        private PopupArtistsViewModel model = null;
        protected override void OnDisappearing() => CallbackEvent?.Invoke(this, _selectedArtist);

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            _selectedArtist = await _artistService.GetById<Model.Artist>(model.selectedArtist.ArtistId);
            await PopupNavigation.Instance.PopAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            _selectedArtist = new Model.Artist() { ArtistId = 0, ArtistName = "Not Selected" };
            await PopupNavigation.Instance.PopAsync();
        }
    }
}