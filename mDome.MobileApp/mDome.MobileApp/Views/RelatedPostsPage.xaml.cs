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
    public partial class RelatedPostsPage : ContentPage
    {
        public RelatedPostsPage(int? artistRelatedId, int? userRelatedId)
        {
            InitializeComponent();
            BindingContext = vm = new RelatedPostsViewModel();
            vm.UserRelatedId = userRelatedId;
            vm.ArtistRelatedId = artistRelatedId;
            vm.InitCommand.Execute(null);
        }
        RelatedPostsViewModel vm = null;

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new PostPage(vm.SelectedPost.PostId));
        }
    }
}