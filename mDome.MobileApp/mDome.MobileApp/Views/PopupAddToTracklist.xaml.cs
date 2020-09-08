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
    public partial class PopupAddToTracklist : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopupAddToTracklist(int trackId)
        {
            InitializeComponent();
            BindingContext = vm = new PopupAddToTracklistViewModel();
            vm.ThisTrackId = trackId;
            vm.InitCommand.Execute(null);
        }
        PopupAddToTracklistViewModel vm;
        public int _selectedTracklistId;
        public event EventHandler<object> CallbackEvent;
        protected override void OnDisappearing() => CallbackEvent?.Invoke(this, _selectedTracklistId);
        private async void Button_Clicked(object sender, EventArgs e)
        {
            _selectedTracklistId = 0;
            await PopupNavigation.Instance.PopAsync();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _selectedTracklistId = vm.SelectedTracklist.TracklistId;
            await PopupNavigation.Instance.PopAsync();
        }

    }
}