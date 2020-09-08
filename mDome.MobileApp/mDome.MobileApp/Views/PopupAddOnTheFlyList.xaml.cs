using mDome.MobileApp.ViewModels;
using Rg.Plugins.Popup.Pages;
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
    public partial class PopupAddOnTheFlyList : PopupPage
    {
        public PopupAddOnTheFlyList(bool isAlbumList)
        {
            InitializeComponent();
            BindingContext = vm = new AddListOnTheFlyViewModel();
            vm.IsAlbumList = isAlbumList;
            vm.DisappearHandler += async (object sender, object e) =>
            {
                await PopupNavigation.Instance.PopAsync();
            };

        }
        public event EventHandler<object> CallbackEvent;
        protected override void OnDisappearing() => CallbackEvent?.Invoke(this, true);

        AddListOnTheFlyViewModel vm;

        private async void Disappear(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}