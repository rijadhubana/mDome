using mDome.MobileApp.Helper;
using mDome.MobileApp.Views;
using mDome.Model;
using mDome.Model.Requests;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace mDome.MobileApp.ViewModels
{
    class TrackViewModel : BaseViewModel
    {
        private readonly APIService _trackService = new APIService("Track");
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _artistService = new APIService("Artist");
        private readonly APIService _userTrackVoteService = new APIService("UserTrackVote");
        private readonly APIService _tracklistTrackService = new APIService("TracklistTrack");
        private readonly APIService _tracklistService = new APIService("Tracklist");
        public TrackViewModel()
        {
            InitCommand = new Command(async () => await Init());
            LikeCommand = new Command(async () => await Like());
            DislikeCommand = new Command(async () => await Dislike());
            AddToTracklistCommand = new Command(async () => await AddToTracklist());
        }
        public ICommand InitCommand { get; set; }
        public ICommand LikeCommand { get; set; }
        public ICommand DislikeCommand { get; set; }
        public ICommand AddToTracklistCommand { get; set; }

        public int TrackId { get; set; }
        Track _loadedTrack;
        public Track LoadedTrack
        {
            get
            {
                return _loadedTrack;
            }

            set
            {
                _loadedTrack = value;
                OnPropertyChanged("LoadedTrack");
            }
        }
        string _webViewSource;
        public string WebViewSource
        {
            get
            {
                return _webViewSource;
            }

            set
            {
                _webViewSource = value;
                OnPropertyChanged("WebViewSource");
            }
        }
        string _trackName;
        public string TrackName
        {
            get
            {
                return _trackName;
            }

            set
            {
                _trackName = value;
                OnPropertyChanged("TrackName");
            }
        }
        string _trackViews;
        public string TrackViews
        {
            get
            {
                return _trackViews;
            }

            set
            {
                _trackViews = value;
                OnPropertyChanged("TrackViews");
            }
        }
        string _albumName;
        public string AlbumName
        {
            get
            {
                return _albumName;
            }

            set
            {
                _albumName = value;
                OnPropertyChanged("AlbumName");
            }
        }
        string _artistName;
        public string ArtistName
        {
            get
            {
                return _artistName;
            }

            set
            {
                _artistName = value;
                OnPropertyChanged("ArtistName");
            }
        }
        public Album ThisAlbum { get; set; }
        public Artist ThisArtist { get; set; }
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
        private async Task AddToTracklist()
        {
            var popUp = new PopupAddToTracklist(TrackId);
            int placeholderId;
            popUp.CallbackEvent += async (object sender, object e) =>
            {
                placeholderId = (int)e;
                if (placeholderId == 0)
                    return;
                else
                {
                    TracklistTrackUpsertRequest req = new TracklistTrackUpsertRequest()
                    {
                        TrackId = TrackId,
                        TracklistId = placeholderId,
                        DateAdded = DateTime.Now
                    };
                   await _tracklistTrackService.Insert<TracklistTrack>(req);
                   await Application.Current.MainPage.DisplayAlert("Success", "Track successfully added to tracklist!", "OK");
                }

            };
            await PopupNavigation.Instance.PushAsync(popUp);
        }
        private async Task AddOrRemoveFromLikedTracks(bool remove = false)
        {
            var likedTracksList = await _tracklistService.Get<List<Tracklist>>(new TracklistSearchRequest()
            { UserId = APIService.loggedProfile.UserId, TracklistName = "Liked Tracks" });
            int idList = likedTracksList.First().TracklistId;
            if (remove == false)
            {
                await _tracklistTrackService.Insert<TracklistTrack>(new TracklistTrackUpsertRequest()
                {
                    TrackId=TrackId,
                    TracklistId=idList
                });
            }
            else
            {
                await _tracklistTrackService.Update<TracklistTrack>(0, new TracklistTrackUpsertRequest()
                {
                    TrackId = TrackId,
                    TracklistId = idList
                });
            }
        }
        private async Task Like()
        {
            var likedRes = await _userTrackVoteService.Get<List<Model.UserTrackVote>>(new UserTrackVoteSearchRequest
            {
                UserId = APIService.loggedProfile.UserId,
                TrackId = TrackId
            });
            UserTrackVote local = likedRes.FirstOrDefault();
            if (local == null)
            {
                UserTrackVoteUpsertRequest request = new UserTrackVoteUpsertRequest() { Liked = true, UserId = APIService.loggedProfile.UserId, TrackId=TrackId };
                try
                {
                    await _userTrackVoteService.Insert<Model.UserAlbumVote>(request);
                    await GlobalMethods.GenerateRating(ThisAlbum.AlbumId);
                    await AddOrRemoveFromLikedTracks(false);
                    await SetLikeDislike();
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
            else if (local.Liked == true || local.Liked == false)
            {
                try
                {
                    await _userTrackVoteService.Update<Model.UserTrackVote>(0, new UserTrackVoteUpsertRequest()
                    {
                        Liked = true,
                        TrackId = TrackId,
                        UserId = APIService.loggedProfile.UserId
                    });
                    await GlobalMethods.GenerateRating(ThisAlbum.AlbumId);
                    if (local.Liked == true)
                        await AddOrRemoveFromLikedTracks(true);
                    else await AddOrRemoveFromLikedTracks(false);
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
            var likedRes = await _userTrackVoteService.Get<List<Model.UserTrackVote>>(new UserTrackVoteSearchRequest
            {
                UserId = APIService.loggedProfile.UserId,
                TrackId=TrackId
            });
            UserTrackVote local = likedRes.FirstOrDefault();
            if (local == null)
            {
                UserTrackVoteUpsertRequest request = new UserTrackVoteUpsertRequest() { Liked = false, UserId = APIService.loggedProfile.UserId, TrackId=TrackId };
                try
                {
                    await _userTrackVoteService.Insert<Model.UserAlbumVote>(request);
                    await GlobalMethods.GenerateRating(ThisAlbum.AlbumId);
                    await SetLikeDislike();
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
            else if (local.Liked == false || local.Liked == true)
            {
                try
                {
                    await _userTrackVoteService.Update<Model.UserTrackVote>(0, new UserTrackVoteUpsertRequest()
                    {
                        Liked = false,
                        TrackId=TrackId,
                        UserId = APIService.loggedProfile.UserId
                    });
                    await GlobalMethods.GenerateRating(ThisAlbum.AlbumId);
                    if (local.Liked == true)
                        await AddOrRemoveFromLikedTracks(true);
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
            var likedRes = await _userTrackVoteService.Get<List<Model.UserTrackVote>>(new UserTrackVoteSearchRequest
            {
                UserId = APIService.loggedProfile.UserId,
                TrackId=TrackId
            });
            UserTrackVote local = likedRes.FirstOrDefault();
            var numberOfLikes = await _userTrackVoteService.Get<List<Model.UserTrackVote>>(new UserTrackVoteSearchRequest()
            {
                TrackId = TrackId,
                Liked = true
            });
            var numberOfDislikes = await _userTrackVoteService.Get<List<Model.UserTrackVote>>(new UserTrackVoteSearchRequest()
            {
                TrackId=TrackId,
                Liked = false
            });
            NumberOfLikes = numberOfLikes.Count();
            NumberOfDislikes = numberOfDislikes.Count();
            if (local == null)
            {
                LikeSource = ImageSource.FromFile("like.png");
                DislikeSource = ImageSource.FromFile("dislike.png");
            }
            else if (local.Liked == true)
            {
                LikeSource = ImageSource.FromFile("alreadyliked.png");
                DislikeSource = ImageSource.FromFile("dislike.png");
            }
            else if (local.Liked == false)
            {
                LikeSource = ImageSource.FromFile("like.png");
                DislikeSource = ImageSource.FromFile("alreadydisliked.png");
            }
        }
        private async Task Init()
        {
            LoadedTrack = await _trackService.GetById<Track>(TrackId);
            WebViewSource = "https://www.youtube.com/embed/" + LoadedTrack.TrackYoutubeId;
            ThisAlbum = await _albumService.GetById<Album>(LoadedTrack.AlbumId);
            ThisArtist = await _artistService.GetById<Artist>(ThisAlbum.ArtistId);
            TrackName = "Track Name: " + LoadedTrack.TrackName;
            TrackViews = "mDome Views: " + LoadedTrack.TrackViews;
            AlbumName = "Album Name: " + ThisAlbum.AlbumName;
            ArtistName = "Artist Name: " + ThisArtist.ArtistName;
            await SetLikeDislike();
            await GlobalMethods.IncreaseViewCountUpdateHistory(TrackId);

        }
    }
}
