using mDome.MobileApp.ViewModels;
using Plugin.InputKit.Shared.Controls;
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
    public partial class AddNewReviewPage : ContentPage
    {
        public AddNewReviewPage(int albumId)
        {
            InitializeComponent();
            BindingContext = vm = new AddReviewViewModel();
            vm.ThisAlbumId = albumId;
            vm.InitCommand.Execute(null);
            vm.PopHandler += (object s, EventArgs r) =>
            {
                Navigation.PopAsync();
            };
        }
        AddReviewViewModel vm;

        private void FavTrackChanged(object sender, EventArgs e)
        {
            Plugin.InputKit.Shared.Controls.CheckBox cb = sender as Plugin.InputKit.Shared.Controls.CheckBox;
            vm.FavTrackCheckedCommand.Execute(cb.Key);
        }

        private void LeastFavTrackChanged(object sender, EventArgs e)
        {
            Plugin.InputKit.Shared.Controls.CheckBox cb = sender as Plugin.InputKit.Shared.Controls.CheckBox;
            vm.LeastFavTrackCheckedCommand.Execute(cb.Key);
        }
    }
}