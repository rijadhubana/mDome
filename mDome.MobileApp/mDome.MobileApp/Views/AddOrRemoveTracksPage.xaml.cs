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
    public partial class AddOrRemoveTracksPage : ContentPage
    {
        public AddOrRemoveTracksPage(int tracklistId, bool add)
        {
            InitializeComponent();
            BindingContext = vm = new AddOrRemoveTracksViewModel();
            vm.TracklistId = tracklistId;
            vm.AddTracks = add;
            vm.InitCommand.Execute(null);
        }
        AddOrRemoveTracksViewModel vm;

        private void ClickedEvent(object sender, SelectedItemChangedEventArgs e)
        {
            vm.ClickedCommand.Execute(null);
        }
    }
}