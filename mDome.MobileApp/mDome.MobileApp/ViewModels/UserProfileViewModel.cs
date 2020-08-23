using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace mDome.MobileApp.ViewModels
{
    class UserProfileViewModel : BaseViewModel
    {
        private readonly APIService _userService = new APIService("UserProfile");
        private readonly APIService _artistService = new APIService("Artist");
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _userFollowersService = new APIService("UserFollowers");
        public UserProfileViewModel()
        {
            InitCommand = new Command(async () => await Init());
            FollowCommand = new Command(async () => await Follow());
            UnfollowCommand = new Command(async () => await Unfollow());
        }
        Model.UserProfile _shownProfile = null;
        public Model.UserProfile ShownProfile
        {
            get
            {
                return _shownProfile;
            }

            set
            {
                _shownProfile = value;
                OnPropertyChanged("ShownProfile");
            }
        }
        public int UserId { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand FollowCommand { get; set; }
        public ICommand UnfollowCommand { get; set; }
        Model.Album _album1;
        public Model.Album Album1
        {
            get
            {
                return _album1;
            }

            set
            {
                _album1 = value;
                OnPropertyChanged("Album1");
            }
        }
        Model.Album _album2;
        public Model.Album Album2
        {
            get
            {
                return _album2;
            }

            set
            {
                _album2 = value;
                OnPropertyChanged("Album2");
            }
        }
        Model.Album _album3;
        public Model.Album Album3
        {
            get
            {
                return _album3;
            }

            set
            {
                _album3 = value;
                OnPropertyChanged("Album3");
            }
        }
        Model.Artist _artist1;
        public Model.Artist Artist1
        {
            get
            {
                return _artist1;
            }

            set
            {
                _artist1 = value;
                OnPropertyChanged("Artist1");
            }
        }
        Model.Artist _artist2;
        public Model.Artist Artist2
        {
            get
            {
                return _artist2;
            }

            set
            {
                _artist2 = value;
                OnPropertyChanged("Artist2");
            }
        }
        Model.Artist _artist3;
        public Model.Artist Artist3
        {
            get
            {
                return _artist3;
            }

            set
            {
                _artist3 = value;
                OnPropertyChanged("Artist3");
            }
        }
        bool _followButtonIsVisible;
        public bool FollowButtonIsVisible
        {
            get
            {
                return _followButtonIsVisible;
            }

            set
            {
                _followButtonIsVisible = value;
                OnPropertyChanged("FollowButtonIsVisible");
            }
        }
        bool _unfollowButtonIsVisible;
        public bool UnfollowButtonIsVisible
        {
            get
            {
                return _unfollowButtonIsVisible;
            }

            set
            {
                _unfollowButtonIsVisible = value;
                OnPropertyChanged("UnfollowButtonIsVisible");
            }
        }
        bool _editProfileButtonIsVisible;
        public bool EditProfileButtonIsVisible
        {
            get
            {
                return _editProfileButtonIsVisible;
            }

            set
            {
                _editProfileButtonIsVisible = value;
                OnPropertyChanged("EditProfileButtonIsVisible");
            }
        }
        private async Task Follow()
        {
            UserFollowersUpsertRequest request = new UserFollowersUpsertRequest
            {
                UserId = ShownProfile.UserId,
                FollowedByUserId = APIService.loggedProfile.UserId
            };
            await _userFollowersService.Insert<Model.UserFollowers>(request);
            await SetButtons();
        }
        private async Task Unfollow()
        {
            UserFollowersUpsertRequest request = new UserFollowersUpsertRequest
            {
                UserId = ShownProfile.UserId,
                FollowedByUserId = APIService.loggedProfile.UserId
            };
            await _userFollowersService.Update<Model.UserFollowers>(0, request);
            await SetButtons();
        }
        private async Task SetRecommended()
        {
            var allArtists = await _artistService.Get<List<Model.Artist>>(null);
            var allAlbums = await _albumService.Get<List<Model.Album>>(null);

            if (ShownProfile.RecommendedAlbum1.HasValue)
                Album1 = allAlbums.Where(a => a.AlbumId == ShownProfile.RecommendedAlbum1).FirstOrDefault();
            else
            {
                Album1 = new Model.Album() { AlbumName = "N/A", AlbumId = 0, AlbumPhoto=File.ReadAllBytes("none.png") };
            }
            if (ShownProfile.RecommendedAlbum2.HasValue)
                Album2 = allAlbums.Where(a => a.AlbumId == ShownProfile.RecommendedAlbum2).FirstOrDefault();
            else
            {
                Album2 = new Model.Album() { AlbumName = "N/A", AlbumId = 0, AlbumPhoto=File.ReadAllBytes("none.png") };
            }
            if (ShownProfile.RecommendedAlbum3.HasValue)
                Album3 = allAlbums.Where(a => a.AlbumId == ShownProfile.RecommendedAlbum3).FirstOrDefault();
            else
            {
                Album3 = new Model.Album() { AlbumName = "N/A", AlbumId = 0, AlbumPhoto = File.ReadAllBytes("none.png") };
            }
            if (ShownProfile.RecommendedArtist1.HasValue)
                Artist1 = allArtists.Where(a => a.ArtistId == ShownProfile.RecommendedArtist1).FirstOrDefault();
            else
            {
                Artist1 = new Model.Artist() { ArtistName = "N/A", ArtistId = 0, ArtistPhoto = File.ReadAllBytes("none.png") };
            }
            if (ShownProfile.RecommendedArtist2.HasValue)
                Artist2 = allArtists.Where(a => a.ArtistId == ShownProfile.RecommendedArtist2).FirstOrDefault();
            else
            {
                Artist2 = new Model.Artist() { ArtistName = "N/A", ArtistId = 0, ArtistPhoto = File.ReadAllBytes("none.png") };
            }
            if (ShownProfile.RecommendedArtist3.HasValue)
                Artist3 = allArtists.Where(a => a.ArtistId == ShownProfile.RecommendedArtist3).FirstOrDefault();
            else
            {
                Artist3 = new Model.Artist() { ArtistName = "N/A", ArtistId = 0, ArtistPhoto = File.ReadAllBytes("none.png") };
            }

        }
        private async Task SetButtons()
        {
            if (_shownProfile.UserId==APIService.loggedProfile.UserId)
            {
                EditProfileButtonIsVisible = true;
                FollowButtonIsVisible = false;
                UnfollowButtonIsVisible = false;
                return;
            }
            var result = await _userFollowersService.Get<List<Model.UserFollowers>>(new UserFollowersSearchRequest()
            {
                UserId = _shownProfile.UserId,
                FollowedByUserId = APIService.loggedProfile.UserId
            });
            if (result.Count()==0)
            {
                EditProfileButtonIsVisible = false;
                FollowButtonIsVisible = true;
                UnfollowButtonIsVisible = false;
            }
            else
            {
                EditProfileButtonIsVisible = false;
                FollowButtonIsVisible = false;
                UnfollowButtonIsVisible = true;
            }
        }
        private async Task Init()
        {
            ShownProfile = await _userService.GetById<Model.UserProfile>(UserId);
            await SetRecommended();
            await SetButtons();
        }
    }
}
