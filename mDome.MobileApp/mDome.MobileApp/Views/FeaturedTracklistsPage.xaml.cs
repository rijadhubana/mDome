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
    public partial class FeaturedTracklistsPage : ContentPage
    {
        public FeaturedTracklistsPage(int userId)
        {
            InitializeComponent();
            BindingContext = vm = new FeaturedTracklistsViewModel();
            vm.UserId = userId;
            vm.InitCommand.Execute(null);
        }
        FeaturedTracklistsViewModel vm;
        private async void VisitTracklist(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new TracklistPage(vm.SelectedTrackList.TracklistId));
        }
    }
}