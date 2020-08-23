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
    public partial class TracklistPage : ContentPage
    {
        public TracklistPage(int tracklistPageId)
        {
            InitializeComponent();
            BindingContext = vm = new TracklistPageViewModel();
            vm.ThisTracklistId = tracklistPageId;
            vm.InitCommand.Execute(null);
        }
        TracklistPageViewModel vm;

        private async void AddTracks(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddOrRemoveTracksPage(vm.ThisTracklistId, true));
        }

        private async void RemoveTracks(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddOrRemoveTracksPage(vm.ThisTracklistId, false));
        }
        private async void VisitTrack(object sender, EventArgs e)
        {
            StackLayout stack = sender as StackLayout;
            Label labelWithId = stack.Children[0] as Label;
            string abc = labelWithId.Text;
            await Navigation.PushAsync(new TrackPage(int.Parse(abc)));
        }
    }
}