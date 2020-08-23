using mDome.MobileApp.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage(bool editProfile)
        {
            InitializeComponent();
            BindingContext = vm = new RegisterViewModel();
            vm.EditProfile = editProfile;
            if (vm.EditProfile == true)
                vm.EditProfileCommand.Execute(null);
        }
        RegisterViewModel vm = null;
    }
}