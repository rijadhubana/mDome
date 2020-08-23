using mDome.MobileApp.Helper;
using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace mDome.MobileApp.ViewModels
{
    class RelatedReviewsViewModel : BaseViewModel
    {
        private readonly APIService _reviewService = new APIService("Review");
        private readonly APIService _postService = new APIService("Post");
        private readonly APIService _artistService = new APIService("Artist");
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _userService = new APIService("UserProfile");
        public RelatedReviewsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ICommand InitCommand { get; set; }
        public int? UserRelatedReviews { get; set; } = null;
        public int? ArtistRelatedReviews { get; set; } = null;
        public int? AlbumRelatedReviews { get; set; } = null;
        public ObservableCollection<ReviewPostHelperVM> ReviewList { get; set; } = new ObservableCollection<ReviewPostHelperVM>();
        ReviewPostHelperVM _selectedReview;
        public ReviewPostHelperVM SelectedReview
        {
            get
            {
                return _selectedReview;
            }

            set
            {
                _selectedReview = value;
                OnPropertyChanged("SelectedReview");
            }
        }
        private async Task LoadIfUserRelated()
        {
            var reviews = await _reviewService.Get<List<Review>>(new ReviewSearchRequest() { UserId = UserRelatedReviews });
            foreach (var item in reviews)
            {
                var query = await _postService.Get<List<Post>>(new PostSearchRequest() { ReviewRelatedId = item.ReviewId });
                var thisPost = query.FirstOrDefault();
                ReviewPostHelperVM local = new ReviewPostHelperVM()
                {
                    ReviewId = item.ReviewId,
                    FavouriteSongs = item.FavouriteSongs,
                    LeastFavouriteSongs = item.LeastFavouriteSongs,
                    PostDateTime = thisPost.PostDateTime,
                    PostId = thisPost.PostId,
                    PostPhoto = thisPost.PostPhoto,
                    Username = thisPost.AdminName,
                    Rating = "Rating: " + item.Rating.ToString() + "/5",
                    ReviewText = item.ReviewText
                };
                ReviewList.Add(local);
            }
        }
        private async Task LoadIfArtistRelated()
        {
            var albums = await _albumService.Get<List<Album>>(new AlbumSearchRequest() { ArtistId = ArtistRelatedReviews });
            foreach (var item in albums)
            {
                var reviews = await _reviewService.Get<List<Review>>(new ReviewSearchRequest() { AlbumId = item.AlbumId });
                foreach (var x in reviews)
                {
                    var returnedPost = await _postService.Get<List<Post>>(new PostSearchRequest() { ReviewRelatedId = x.ReviewId });
                    var thisPost = returnedPost.FirstOrDefault();
                    ReviewPostHelperVM local = new ReviewPostHelperVM()
                    {
                        ReviewId = x.ReviewId,
                        FavouriteSongs = x.FavouriteSongs,
                        LeastFavouriteSongs = x.LeastFavouriteSongs,
                        PostDateTime = thisPost.PostDateTime,
                        PostId = thisPost.PostId,
                        Username = thisPost.AdminName,
                        PostPhoto = thisPost.PostPhoto,
                        Rating = "Rating: " + x.Rating.ToString() + "/5",
                        ReviewText = x.ReviewText
                    };
                    ReviewList.Add(local);
                }
            }
        }
        private async Task LoadIfAlbumRelated()
        {
            var reviews = await _reviewService.Get<List<Review>>(new ReviewSearchRequest() { AlbumId = AlbumRelatedReviews });
            foreach (var item in reviews)
            {
                var query = await _postService.Get<List<Post>>(new PostSearchRequest() { ReviewRelatedId = item.ReviewId });
                var thisPost = query.FirstOrDefault();
                ReviewPostHelperVM local = new ReviewPostHelperVM()
                {
                    ReviewId = item.ReviewId,
                    FavouriteSongs = item.FavouriteSongs,
                    LeastFavouriteSongs = item.LeastFavouriteSongs,
                    PostDateTime = thisPost.PostDateTime,
                    PostId = thisPost.PostId,
                    Username = thisPost.AdminName,
                    PostPhoto = thisPost.PostPhoto,
                    Rating = "Rating: " + item.Rating.ToString() + "/5",
                    ReviewText = item.ReviewText
                };
                ReviewList.Add(local);
            }
        }
        private async Task Init()
        {
            if (UserRelatedReviews.HasValue)
            {
                await LoadIfUserRelated();
            }
            else if (ArtistRelatedReviews.HasValue)
            {
                await LoadIfArtistRelated();
            }
            else if (AlbumRelatedReviews.HasValue)
            {
                await LoadIfAlbumRelated();
            }
        }
    }
}
