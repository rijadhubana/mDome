using mDome.MobileApp.ViewModels;
using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mDome.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterView : ContentPage
    {
        public MasterView()
        {
            InitializeComponent();
            BindingContext = vm = new MasterViewModel();
        }
        MasterViewModel vm  = null;
        public event EventHandler<object> masterViewEventHandler;
        private void MenuItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            masterViewEventHandler?.Invoke(this, vm.SelectedMenuItem);
        }
        public void SetPropertySelected()
        {
            vm.SelectedMenuItem = "";
        }
    }
}