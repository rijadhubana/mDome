using mDome.MobileApp.Helper;
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
    class ArtistViewModel : BaseViewModel
    {
        private readonly APIService _artistService = new APIService("Artist");
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _trackService = new APIService("Track");
        private readonly APIService _userFollowsArtistService = new APIService("UserFollowsArtist");
        public ArtistViewModel()
        {
            InitCommand = new Command(async () => await Init());
            FollowCommand = new Command(async () => await Follow());
            UnfollowCommand = new Command(async () => await Unfollow());
        }
        public ICommand InitCommand { get; set; }
        public ICommand FollowCommand { get; set; }
        public ICommand UnfollowCommand { get; set; }
        public int ArtistId { get; set; }
        Artist _loadedArtist;
        public Artist LoadedArtist
        {
            get
            {
                return _loadedArtist;
            }

            set
            {
                _loadedArtist = value;
                OnPropertyChanged("LoadedArtist");
            }
        }
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
        Model.Track _selectedTrack;
        public Model.Track SelectedTrack
        {
            get
            {
                return _selectedTrack;
            }

            set
            {
                _selectedTrack = value;
                OnPropertyChanged("SelectedTrack");
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
        string _numberOfFollowers;
        public string NumberOfFollowers
        {
            get
            {
                return _numberOfFollowers;
            }

            set
            {
                _numberOfFollowers = value;
                OnPropertyChanged("NumberOfFollowers");
            }
        }


        public ObservableCollectionFast<Track> PopularTracks { get; set; } = new ObservableCollectionFast<Track>();


        private async Task LoadAlbums()
        {
            var albumsReturned = await _albumService.Get<List<Album>>(new AlbumSearchRequest() { ArtistId = ArtistId });
            List<Tuple<int, Album>> viewsPlusAlbum = new List<Tuple<int, Album>>();
            foreach (var item in albumsReturned)
            {
                var allTracks = await _trackService.Get<List<Track>>(new TrackSearchRequest() { AlbumId = item.AlbumId });
                int? views = allTracks.Sum(a => a.TrackViews);
                if (views.HasValue)
                    viewsPlusAlbum.Add(new Tuple<int, Album>((int)views,item));
                else
                    viewsPlusAlbum.Add(new Tuple<int, Album>(0, item));
            }
            viewsPlusAlbum.Sort((x, y) => y.Item1.CompareTo(x.Item1));
            if (viewsPlusAlbum.Count==0)
            {
                Album1 = new Album() { AlbumName = "N/A", AlbumId = 0, AlbumPhoto = File.ReadAllBytes("none.png") };
                Album2 = Album3 = Album1;
            }
            else if (viewsPlusAlbum.Count==1)
            {
                Album2 = Album3 = new Album() { AlbumName = "N/A", AlbumId = 0, AlbumPhoto = File.ReadAllBytes("none.png") };
                Album1 = viewsPlusAlbum.ElementAt(0).Item2;

            }
            else if (viewsPlusAlbum.Count == 2)
            {
                Album3 = new Album() { AlbumName = "N/A", AlbumId = 0, AlbumPhoto = File.ReadAllBytes("none.png") };
                Album1 = viewsPlusAlbum.ElementAt(0).Item2;
                Album2 = viewsPlusAlbum.ElementAt(1).Item2;
            }
            else
            {
                Album1 = viewsPlusAlbum.ElementAt(0).Item2;
                Album2 = viewsPlusAlbum.ElementAt(1).Item2;
                Album3 = viewsPlusAlbum.ElementAt(2).Item2;
            }

        }
        private async Task LoadTracks()
        {
            var tracksReturned = await _trackService.Get<List<Track>>(null);
            var albumsReturned = await _albumService.Get<List<Album>>(new AlbumSearchRequest() { ArtistId = ArtistId });
            List<Track> alltracksthisartist = new List<Track>();
            foreach (var item in albumsReturned)
            {
                alltracksthisartist.AddRange(tracksReturned.Where(a => a.AlbumId == item.AlbumId).ToList());
            }
            var sortedFirst10 = alltracksthisartist.OrderByDescending(a => a.TrackViews).Take(10);
            PopularTracks.AddRange(sortedFirst10);
        }
        private async Task SetButtons()
        {
            var allFollowers = await _userFollowsArtistService.Get<List<UserFollowsArtist>>(new UserFollowsArtistSearchRequest()
            { 
                 ArtistId=ArtistId
            });
            NumberOfFollowers = "Followers: " + allFollowers.Count.ToString();
            if (allFollowers.Where(a=>a.UserId==APIService.loggedProfile.UserId && a.ArtistId==ArtistId).FirstOrDefault()==null)
            {
                FollowButtonIsVisible = true;
                UnfollowButtonIsVisible = false;
            }    
            else
            {
                FollowButtonIsVisible = false;
                UnfollowButtonIsVisible = true;
            }
        }
        private async Task Follow()
        {
            await _userFollowsArtistService.Insert<Model.UserFollowsArtist>(new UserFollowsArtistUpsertRequest()
            {
                ArtistId = ArtistId,
                UserId = APIService.loggedProfile.UserId
            });
            await SetButtons();
        }
        private async Task Unfollow()
        {
            await _userFollowsArtistService.Update<Model.UserFollowsArtist>(0, new UserFollowsArtistUpsertRequest()
            {
                ArtistId = ArtistId,
                UserId = APIService.loggedProfile.UserId
            });
            await SetButtons();

        }
        private async Task Init()
        {
            LoadedArtist = await _artistService.GetById<Model.Artist>(ArtistId);
            await LoadAlbums();
            await LoadTracks();
            await SetButtons();
        }
    }
}
