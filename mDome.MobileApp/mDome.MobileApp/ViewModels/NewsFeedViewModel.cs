using mDome.MobileApp.Helper;
using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace mDome.MobileApp.ViewModels
{
    class NewsFeedViewModel : BaseViewModel
    {
        private readonly APIService _userFollowersService = new APIService("UserFollowers");
        private readonly APIService _userFollowsArtistService = new APIService("UserFollowsArtist");
        private readonly APIService _postService = new APIService("Post");
        Model.UserProfile current = APIService.loggedProfile;
        public NewsFeedViewModel()
        {
            LoadPostsCommand = new Command(async () => await LoadPosts());
            LoadPostsCommand.Execute(null);
        }
        public ICommand LoadPostsCommand { get; set; }
        public ObservableCollection<PostHelperVM> loadedPosts { get; set; } = new ObservableCollection<PostHelperVM>();
        PostHelperVM _selectedPost;
        public PostHelperVM selectedPost
        {
            get
            {
                return _selectedPost;
            }

            set
            {
                _selectedPost = value;
                OnPropertyChanged("selectedPost");
            }
        }

        private async Task LoadPosts()
        {
            var allFollowers = await _userFollowersService.Get<List<Model.UserFollowers>>(new UserFollowersSearchRequest() { FollowedByUserId=current.UserId});
            var allFollowedArtists = await _userFollowsArtistService.Get<List<Model.UserFollowsArtist>>(new UserFollowsArtistSearchRequest() {  UserId=current.UserId});
            var allPosts = await _postService.Get<List<Model.Post>>(null);
            var localPosts = new ObservableCollectionFast<Post>();
            localPosts.AddRange(allPosts.Where(a=> a.IsGlobal.HasValue && a.IsGlobal==true).ToList());
            localPosts.AddRange(allPosts.Where(a => a.ArtistRelatedId!=null 
            && a.ArtistRelatedId==allFollowedArtists.Where(b=>b.ArtistId==a.ArtistRelatedId).Select(c=>c.ArtistId).FirstOrDefault()).ToList());
            localPosts.AddRange(allPosts.Where(a => a.UserRelatedId!=null
            && a.UserRelatedId == allFollowers.Where(b => b.UserId == a.UserRelatedId &&
            b.FollowedByUserId==APIService.loggedProfile.UserId).Select(c => c.UserId).FirstOrDefault()).ToList());
            localPosts.AddRange(allPosts.Where(a => a.UserRelatedId != null
            && a.UserRelatedId == APIService.loggedProfile.UserId).ToList());
            var dist = localPosts.Distinct().OrderByDescending(a => a.PostDateTime);
            foreach (var item in dist)
            {
                loadedPosts.Add(new PostHelperVM()
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
