using mDome.MobileApp.Helper;
using mDome.MobileApp.ViewModels;
using mDome.MobileApp.Views;
using mDome.Model;
using mDome.Model.Requests;
using Rg.Plugins.Popup.Services;
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
    class AlbumViewModel : BaseViewModel
    {
        private readonly APIService _artistService = new APIService("Artist");
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _userAlbumVote = new APIService("UserAlbumVote");
        private readonly APIService _trackService = new APIService("Track");
        private readonly APIService _albumListService = new APIService("AlbumList");
        private readonly APIService _albumListAlbumService = new APIService("AlbumListAlbum");
        public AlbumViewModel()
        {
            InitCommand = new Command(async () => await Init());
            LikeCommand = new Command(async () => await Like());
            DislikeCommand = new Command(async () => await Dislike());
            AddToAlbumListCommand = new Command(async () => await AddToAlbumList());
        }
        public ICommand InitCommand { get; set; }
        public ICommand LikeCommand { get; set; }
        public ICommand DislikeCommand { get; set; }
        public ICommand AddToAlbumListCommand { get; set; }
        public int AlbumId { get; set; }
        Model.Album _loadedAlbum;
        public Model.Album LoadedAlbum
        {
            get
            {
                return _loadedAlbum;
            }

            set
            {
                _loadedAlbum = value;
                OnPropertyChanged("LoadedAlbum");
            }
        }
        Model.Artist _loadedArtist;
        public Model.Artist LoadedArtist
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
        string _dateReleased;
        public string DateReleased
        {
            get
            {
                return _dateReleased;
            }

            set
            {
                _dateReleased = value;
                OnPropertyChanged("DateReleased");
            }
        }
        string _ratingStr;
        public string RatingStr
        {
            get
            {
                return _ratingStr;
            }

            set
            {
                _ratingStr = value;
                OnPropertyChanged("RatingStr");
            }
        }
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
        string _webViewString;
        public string WebViewString
        {
            get
            {
                return _webViewString;
            }

            set
            {
                _webViewString = value;
                OnPropertyChanged("WebViewString");
            }
        }
        public ObservableCollection<TrackPlusTrackNumber> TracksOnAlbum { get; set; } = new ObservableCollection<TrackPlusTrackNumber>();
        TrackPlusTrackNumber _selectedTrack;
        public TrackPlusTrackNumber SelectedTrack
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
        private async Task AddToAlbumList()
        {
            var popUp = new PopupAddToAlbumList(AlbumId);
            int placeholderId;
            popUp.CallbackEvent += async (object sender, object e) =>
            {
                placeholderId = (int)e;
                if (placeholderId == 0)
                    return;
                else
                {
                    AlbumListAlbumUpsertRequest req = new AlbumListAlbumUpsertRequest()
                    {
                        AlbumId = AlbumId,
                        AlbumListId = placeholderId
                    };
                    await _albumListAlbumService.Insert<AlbumListAlbum>(req);
                    await Application.Current.MainPage.DisplayAlert("Success", "Album successfully added to album list!", "OK");
                }
            };
            await PopupNavigation.Instance.PushAsync(popUp);
        }
        private async Task AddOrRemoveFromLikedAlbums(bool remove=false)
        {
            var likedAlbumsList = await _albumListService.Get<List<AlbumList>>(new AlbumListSearchRequest()
            { UserId = APIService.loggedProfile.UserId, AlbumListName = "Liked Albums" });
            int idList = likedAlbumsList.First().AlbumListId;
            if (remove==false)
            {
                await _albumListAlbumService.Insert<AlbumListAlbum>(new AlbumListAlbumUpsertRequest()
                {
                    AlbumListId = idList,
                    AlbumId = AlbumId
                });
            }
            else
            {
                await _albumListAlbumService.Update<AlbumListAlbum>(0,new AlbumListAlbumUpsertRequest()
                {
                    AlbumId = AlbumId,
                    AlbumListId = idList
                });
            }
        }
        private async Task Like()
        {
            var likedRes = await _userAlbumVote.Get<List<Model.UserAlbumVote>>(new UserAlbumVoteSearchRequest
            {
                UserId = APIService.loggedProfile.UserId,
                AlbumId = AlbumId
            });
            UserAlbumVote local = likedRes.FirstOrDefault();
            if (local == null)
            {
                UserAlbumVoteUpsertRequest request = new UserAlbumVoteUpsertRequest() { Liked = true, UserId = APIService.loggedProfile.UserId, AlbumId=AlbumId };
                try
                {
                    await _userAlbumVote.Insert<Model.UserAlbumVote>(request);
                    await GlobalMethods.GenerateRating(AlbumId);
                    await AddOrRemoveFromLikedAlbums(false);
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
                    await _userAlbumVote.Update<Model.UserAlbumVote>(0, new UserAlbumVoteUpsertRequest()
                    {
                        Liked = true,
                        AlbumId=AlbumId,
                        UserId = APIService.loggedProfile.UserId
                    });
                    await GlobalMethods.GenerateRating(AlbumId);
                    if (local.Liked == true)
                        await AddOrRemoveFromLikedAlbums(true);
                    else await AddOrRemoveFromLikedAlbums(false);
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
            var likedRes = await _userAlbumVote.Get<List<Model.UserAlbumVote>>(new UserAlbumVoteSearchRequest
            {
                UserId = APIService.loggedProfile.UserId,
                AlbumId=AlbumId
            });
            UserAlbumVote local = likedRes.FirstOrDefault();
            if (local == null)
            {
                UserAlbumVoteUpsertRequest request = new UserAlbumVoteUpsertRequest() { Liked = false, UserId = APIService.loggedProfile.UserId, AlbumId=AlbumId };
                try
                {
                    await _userAlbumVote.Insert<Model.UserAlbumVote>(request);
                    await GlobalMethods.GenerateRating(AlbumId);
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
                    await _userAlbumVote.Update<Model.UserAlbumVote>(0, new UserAlbumVoteUpsertRequest()
                    {
                        Liked = false,
                        AlbumId=AlbumId,
                        UserId = APIService.loggedProfile.UserId
                    });
                    await GlobalMethods.GenerateRating(AlbumId);
                    if (local.Liked == true)
                        await AddOrRemoveFromLikedAlbums(true);
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
            var likedRes = await _userAlbumVote.Get<List<Model.UserAlbumVote>>(new UserAlbumVoteSearchRequest
            {
                UserId = APIService.loggedProfile.UserId,
                AlbumId=AlbumId
            });
            UserAlbumVote local = likedRes.FirstOrDefault();
            var numberOfLikes = await _userAlbumVote.Get<List<Model.UserAlbumVote>>(new UserAlbumVoteSearchRequest()
            {
                AlbumId = LoadedAlbum.AlbumId,
                Liked = true
            });
            var numberOfDislikes = await _userAlbumVote.Get<List<Model.UserAlbumVote>>(new UserAlbumVoteSearchRequest()
            {
                AlbumId = LoadedAlbum.AlbumId,
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
            var reloadedAlbum = await _albumService.GetById<Album>(AlbumId);

            RatingStr = "Rating: " + reloadedAlbum.AlbumGeneratedRating.ToString() + "/5";
        }
        private async Task SetWebViewSource()
        {
            var TracksFromAlbum = await _trackService.Get<List<Model.Track>>(new TrackSearchRequest() { AlbumId = AlbumId });
            WebViewString = "https://www.youtube.com/embed/" + TracksFromAlbum.ElementAt(0).TrackYoutubeId + "?playlist=";
            foreach (var item in TracksFromAlbum)
            {
                //skipping first track since it's already in the embed
                if (item == TracksFromAlbum.ElementAt(0))
                    continue;
                WebViewString += item.TrackYoutubeId;
                //skipping last element because of comma
                if (item == TracksFromAlbum.ElementAt(TracksFromAlbum.Count - 1))
                    continue;
                else WebViewString += ",";
            }
        }
        private async Task SetTracks()
        {
            var tracks = await _trackService.Get<List<Track>>(new TrackSearchRequest() { AlbumId = AlbumId });
            tracks = tracks.OrderBy(a => a.TrackNumber).ToList();
            foreach (var item in tracks)
            {
                TracksOnAlbum.Add(new TrackPlusTrackNumber()
                {
                    TrackId = item.TrackId,
                    TrackNamePlusNumber = item.TrackNumber.ToString() + ". " + item.TrackName
                });
            }
        }
        private async Task Init()
        {
            LoadedAlbum = await _albumService.GetById<Model.Album>(AlbumId);
            LoadedArtist = await _artistService.GetById<Model.Artist>(LoadedAlbum.ArtistId);
            DateReleased = "Date Released: " + LoadedAlbum.DateReleased;
            RatingStr = "Rating: " + LoadedAlbum.AlbumGeneratedRating.ToString()+"/5";
            await SetWebViewSource();
            await SetTracks();

            await SetLikeDislike();
        }
    }
}
