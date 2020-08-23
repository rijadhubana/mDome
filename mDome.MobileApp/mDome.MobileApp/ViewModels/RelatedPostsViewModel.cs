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
    class RelatedPostsViewModel : BaseViewModel
    {
        private readonly APIService _postService = new APIService("Post");
        private readonly APIService _userService = new APIService("UserProfile");
        private readonly APIService _artistService = new APIService("Artist");
        public RelatedPostsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<PostHelperVM> LoadedPosts { get; set; } = new ObservableCollection<PostHelperVM>();
        PostHelperVM _selectedPost;
        public PostHelperVM SelectedPost
        {
            get
            {
                return _selectedPost;
            }

            set
            {
                _selectedPost = value;
                OnPropertyChanged("SelectedPost");
            }
        }
        public int? UserRelatedId { get; set; } = null;
        public int? ArtistRelatedId { get; set; } = null;
        string _postsBy;
        public string PostsBy
        {
            get
            {
                return _postsBy;
            }

            set
            {
                _postsBy = value;
                OnPropertyChanged("PostsBy");
            }
        }
        public ICommand InitCommand { get; set; }
        private async Task Init()
        {
            List<Post> returned = new List<Post>();
            if (UserRelatedId.HasValue)
            {
                returned = await _postService.Get<List<Model.Post>>(new PostSearchRequest { UserRelatedId = UserRelatedId });
                var thisUser = await _userService.GetById<Model.UserProfile>(UserRelatedId);
                PostsBy = "Posts related to " + thisUser.Username;
            }
            else
            {
                returned = await _postService.Get<List<Model.Post>>(new PostSearchRequest() { ArtistRelatedId = ArtistRelatedId });
                var thisArtist = await _artistService.GetById<Artist>(ArtistRelatedId);
                PostsBy = "Posts related to " + thisArtist.ArtistName;
            }
            var sorted = returned.OrderByDescending(a => a.PostDateTime);
            foreach (var item in sorted)
            {
                LoadedPosts.Add(new PostHelperVM
                {
                    AdminName = item.AdminName,
                    OPPhoto = item.Opphoto,
                    PostDateTime = item.PostDateTime,
                    PostId = item.PostId,
                    PostPhoto = item.PostPhoto,
                    PostText = item.PostText,
                    PostTitle = item.PostTitle
                });
            }
            
        }
    }
}
