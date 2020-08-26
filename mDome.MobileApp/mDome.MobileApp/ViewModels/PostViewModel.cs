using mDome.MobileApp.Helper;
using mDome.MobileApp.Views;
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
    class PostViewModel : BaseViewModel
    {
        private readonly APIService _commentService = new APIService("UserCommentPost");
        private readonly APIService _userService = new APIService("UserProfile");
        private readonly APIService _userLikePost = new APIService("UserLikePost");
        private readonly APIService _postService = new APIService("Post");
        private readonly APIService _reviewService = new APIService("Review");

        public PostViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SetLikeDislikeCommand = new Command(async () => await SetLikeDislike());
            LikeCommand = new Command(async () => await Like());
            DislikeCommand = new Command(async () => await Dislike());
            SetButtonsProperty = new Command(async () => await SetButtons());
            DeletePostCommand = new Command(async () => await DeletePost());
        }
        public ICommand InitCommand { get; set; }
        public ICommand SetLikeDislikeCommand { get; set; }
        public ICommand SetButtonsProperty { get; set; }
        public ICommand LikeCommand { get; set; }
        public ICommand DislikeCommand { get; set; }
        public ICommand DeletePostCommand { get; set; }
        private async Task SetButtons()
        {
            var postLocal = await _postService.GetById<Model.Post>(loadedPost.PostId);
            ArtistRelatedId = postLocal.ArtistRelatedId;
            UserRelatedId = postLocal.UserRelatedId;
            if (postLocal.ReviewRelatedId.HasValue)
            {
                var reviewReturned = await _reviewService.GetById<Model.Review>(postLocal.ReviewRelatedId);
                AlbumRelatedId = reviewReturned.AlbumId;
                VisitAlbum = true;
            }
            else VisitAlbum = false;
            if (ArtistRelatedId.HasValue)
                VisitArtist = true;
            if (UserRelatedId.HasValue)
                VisitUser = true;
            if (UserRelatedId.HasValue && UserRelatedId == APIService.loggedProfile.UserId && AlbumRelatedId==null)
                DeleteVisible = true;
        }
        private async Task Init()
        {
            var thisPost = await _postService.GetById<Post>(thisPostId);
            loadedPost = new PostHelperVM()
            {
                AdminName = thisPost.AdminName,
                OPPhoto = thisPost.Opphoto,
                PostDateTime = thisPost.PostDateTime,
                PostId = thisPost.PostId,
                PostPhoto = thisPost.PostPhoto,
                PostText = thisPost.PostText,
                PostTitle = thisPost.PostTitle,
            };
            await SetLikeDislike();
            await SetButtons();
        }
        private async Task Like()
        {
            var likedRes = await _userLikePost.Get<List<Model.UserLikePost>>(new UserLikePostSearchRequest
            {
                UserId = APIService.loggedProfile.UserId,
                PostId = loadedPost.PostId
            });
            UserLikePost local = likedRes.FirstOrDefault();
            if (local==null)
            {
                UserLikePostUpsertRequest request = new UserLikePostUpsertRequest() { Liked = true, UserId = APIService.loggedProfile.UserId, PostId = loadedPost.PostId };
                try
                {
                    await _userLikePost.Insert<Model.UserLikePost>(request);
                    await SetLikeDislike();
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
            else if (local.Liked==true || local.Liked==false)
            {
                try
                {
                    await _userLikePost.Update<Model.UserLikePost>(0,new UserLikePostUpsertRequest()
                    {
                        Liked = true,
                        PostId = loadedPost.PostId,
                        UserId = APIService.loggedProfile.UserId
                    });
                    await SetLikeDislike();
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }
        private async Task Dislike()
        {
            var likedRes = await _userLikePost.Get<List<Model.UserLikePost>>(new UserLikePostSearchRequest
            {
                UserId = APIService.loggedProfile.UserId,
                PostId = loadedPost.PostId
            });
            UserLikePost local = likedRes.FirstOrDefault();
            if (local == null)
            {
                UserLikePostUpsertRequest request = new UserLikePostUpsertRequest() { Liked = false, UserId = APIService.loggedProfile.UserId, PostId = loadedPost.PostId };
                try
                {
                    await _userLikePost.Insert<Model.UserLikePost>(request);
                    await SetLikeDislike();
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
            else if (local.Liked == false || local.Liked==true)
            {
                try
                {
                    await _userLikePost.Update<Model.UserLikePost>(0, new UserLikePostUpsertRequest()
                    {
                        Liked = false,
                        PostId = loadedPost.PostId,
                        UserId = APIService.loggedProfile.UserId
                    });
                    await SetLikeDislike();
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }
        private async Task SetLikeDislike()
        {
            var likedRes = await _userLikePost.Get<List<Model.UserLikePost>>(new UserLikePostSearchRequest
            {
                UserId = APIService.loggedProfile.UserId,
                PostId = loadedPost.PostId });
            UserLikePost local = likedRes.FirstOrDefault();
            var numberOfLikes = await _userLikePost.Get<List<Model.UserLikePost>>(new UserLikePostSearchRequest()
            {
                PostId = loadedPost.PostId,
                Liked = true
            });
            var numberOfDislikes = await _userLikePost.Get<List<Model.UserLikePost>>(new UserLikePostSearchRequest()
            {
                PostId = loadedPost.PostId,
                Liked = false
            });
            NumberOfLikes = numberOfLikes.Count();
            NumberOfDislikes = numberOfDislikes.Count();
            if (local == null)
            {
                LikeSource = ImageSource.FromFile("like.png");
                DislikeSource = ImageSource.FromFile("dislike.png");
            }
            else if (local.Liked==true)
            {
                LikeSource = ImageSource.FromFile("alreadyliked.png");
                DislikeSource = ImageSource.FromFile("dislike.png");
            }
            else if (local.Liked==false)
            {
                LikeSource = ImageSource.FromFile("like.png");
                DislikeSource = ImageSource.FromFile("alreadydisliked.png");
            }
        }
        private async Task DeletePost()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Confirm", "Are you sure you want to remove this post?", "Yes", "No");
            if (answer == false)
                return;
            else
            {
                await _postService.Delete<Post>(thisPostId);
                await Application.Current.MainPage.DisplayAlert("Success", "Post successfully deleted! You will now be redirected to the News Feed page.", "Ok");
                var aps = Application.Current.MainPage as MasterPage;
                await aps.MenuNavigate("News Feed");
            }
        }
        public int thisPostId { get; set; }
        ImageSource _likeSource;
        public ImageSource LikeSource
        {
            get
            {
                return _likeSource;
            }

            set
            {
                _likeSource = value;
                OnPropertyChanged("LikeSource");
            }
        }
        ImageSource _dislikeSource;
        public ImageSource DislikeSource
        {
            get
            {
                return _dislikeSource;
            }

            set
            {
                _dislikeSource = value;
                OnPropertyChanged("DislikeSource");
            }
        }
        PostHelperVM _loadedPost;
        public PostHelperVM loadedPost
        {
            get
            {
                return _loadedPost;
            }

            set
            {
                _loadedPost = value;
                OnPropertyChanged("loadedPost");
            }
        }
        bool _visitArtist = false;
        public bool VisitArtist
        {
            get
            {
                return _visitArtist;
            }

            set
            {
                _visitArtist = value;
                OnPropertyChanged("VisitArtist");
            }
        }
        bool _visitUser = false;
        public bool VisitUser
        {
            get
            {
                return _visitUser;
            }

            set
            {
                _visitUser = value;
                OnPropertyChanged("VisitUser");
            }
        }
        bool _visitAlbum = false;
        public bool VisitAlbum
        {
            get
            {
                return _visitAlbum;
            }

            set
            {
                _visitAlbum = value;
                OnPropertyChanged("VisitAlbum");
            }
        }
        int _numberOfLikes;
        int _numberOfDislikes;
        public int NumberOfLikes
        {
            get
            {
                return _numberOfLikes;
            }

            set
            {
                _numberOfLikes = value;
                OnPropertyChanged("NumberOfLikes");
            }
        }
        public int NumberOfDislikes
        {
            get
            {
                return _numberOfDislikes;
            }

            set
            {
                _numberOfDislikes = value;
                OnPropertyChanged("NumberOfDislikes");
            }
        }
        public int? ArtistRelatedId { get; set; } = null;
        public int? UserRelatedId { get; set; } = null;
        public int? AlbumRelatedId { get; set; } = null;
        bool _deleteVisible = false;
        public bool DeleteVisible
        {
            get
            {
                return _deleteVisible;
            }

            set
            {
                _deleteVisible = value;
                OnPropertyChanged("DeleteVisible");
            }
        }
    }
}
