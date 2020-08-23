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
    public partial class MyTracklistsAlbumlistsPage : BottomBarPage
    {
        public MyTracklistsAlbumlistsPage()
        {
            InitializeComponent();
            BindingContext = vm = new MyTracklistsAlbumListsViewModel();
        }
        MyTracklistsAlbumListsViewModel vm;
        private async void VisitTracklist(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new TracklistPage(vm.SelectedTrackList.TracklistId));
        }

        private async void AddNewTracklist(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewTracklistOrAlbumList(false));
        }

        private async void AddNewAlbumList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewTracklistOrAlbumList(true));
        }

        private async void VisitAlbumList(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new AlbumListPage(vm.SelectedAlbumList.AlbumListId));

        }
    }
}