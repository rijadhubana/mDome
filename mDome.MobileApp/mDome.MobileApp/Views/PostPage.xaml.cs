using mDome.MobileApp.Helper;
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
    public partial class PostPage : ContentPage
    {
        public PostPage(int postId)
        {
            InitializeComponent();
            BindingContext = vm = new PostViewModel();
            vm.thisPostId = postId;
            vm.InitCommand.Execute(null);
            //vm.SetLikeDislikeCommand.Execute(null);
            //vm.SetButtonsProperty.Execute(null);
        }
        PostViewModel vm = null;
        private async void CommentsLikes(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CommentLikePage(vm.loadedPost.PostId));
        }

        private async void VisitUserPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserProfilePage((int)vm.UserRelatedId));
        }

        private async void VisitArtist(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ArtistPage((int)vm.ArtistRelatedId));
        }

        private async void VisitAlbum(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AlbumPage((int)vm.AlbumRelatedId));
        }
    }
}