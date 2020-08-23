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
    public partial class RelatedReviewsPage : ContentPage
    {
        public RelatedReviewsPage(int? albumRelated,int? userRelated,int? artistRelated)
        {
            InitializeComponent();
            BindingContext = vm = new RelatedReviewsViewModel();
            vm.AlbumRelatedReviews = albumRelated;
            vm.ArtistRelatedReviews = artistRelated;
            vm.UserRelatedReviews = userRelated;
            vm.InitCommand.Execute(null);
        }
        RelatedReviewsViewModel vm;
        private async void VisitPost(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new PostPage(vm.SelectedReview.PostId));
        }
    }
}