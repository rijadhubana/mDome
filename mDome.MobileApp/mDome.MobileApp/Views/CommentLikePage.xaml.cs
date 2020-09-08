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
    public partial class CommentLikePage : TabbedPage
    {
        public CommentLikePage(int postId)
        {
            InitializeComponent();
            BindingContext = vm = new CommentsLikesViewModel();
            vm.postId = postId;
            vm.Init.Execute(null);
        }
        CommentsLikesViewModel vm = null;

        private async void VisitUserViaLike(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new UserProfilePage(vm.SelectedUser.UserId));
        }
        private async void VisitUserViaComment(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new UserProfilePage(vm.SelectedCommenter.UserId));
        }
    }
}