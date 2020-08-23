using BottomBar.XamarinForms;
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
    public partial class FollowersFollowingPage : BottomBarPage
    {
        public FollowersFollowingPage()
        {
            InitializeComponent();
            BindingContext = vm = new FollowersFollowingViewModel();
        }
        FollowersFollowingViewModel vm = null;

        private async void VisitUser(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new UserProfilePage(vm.SelectedUser.UserId));
        }
    }
}