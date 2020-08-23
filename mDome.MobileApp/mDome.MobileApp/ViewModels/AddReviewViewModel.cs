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
using Windows.UI.Xaml.Documents;
using Xamarin.Forms;

namespace mDome.MobileApp.ViewModels
{
    class AddReviewViewModel : BaseViewModel
    {
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _trackService = new APIService("Track");
        private readonly APIService _reviewService = new APIService("Review");
        private readonly APIService _postSerivce = new APIService("Post");

        public AddReviewViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SubmitReviewCommand = new Command(async () => await SubmitReview());
            FavTrackCheckedCommand = new Command<int>(FavTrackChecked);
            LeastFavTrackCheckedCommand = new Command<int>(LeastFavTrackChecked);
        }
        public ICommand InitCommand { get; set; }
        public ICommand SubmitReviewCommand { get; set; }
        public ICommand FavTrackCheckedCommand { get; set; }
        public ICommand LeastFavTrackCheckedCommand { get; set; }

        public int ThisAlbumId { get; set; }
        string _reviewText="";
        public string ReviewText
        {
            get
            {
                return _reviewText;
            }

            set
            {
                _reviewText = value;
                OnPropertyChanged("ReviewText");
            }
        }
        string _favTracks="";
        public string FavTracks
        {
            get
            {
                return _favTracks;
            }

            set
            {
                _favTracks = value;
                OnPropertyChanged("FavTracks");
            }
        }
        string _leastFavTracks = "";
        public string LeastFavTracks
        {
            get
            {
                return _leastFavTracks;
            }

            set
            {
                _leastFavTracks = value;
                OnPropertyChanged("LeastFavTracks");
            }
        }
        string _rating="";
        public string Rating
        {
            get
            {
                return _rating;
            }

            set
            {
                _rating = value;
                OnPropertyChanged("Rating");
            }
        }
        Album _loadedAlbum;
        public Album LoadedAlbum
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
        public ObservableCollectionFast<TrackPlusTrackNumber> FavouriteTracksList { get; set; } = new ObservableCollectionFast<TrackPlusTrackNumber>();
        public ObservableCollectionFast<TrackPlusTrackNumber> LeastFavouriteTracksList { get; set; } = new ObservableCollectionFast<TrackPlusTrackNumber>();
        public event EventHandler PopHandler;
        private async Task Init()
        {
            LoadedAlbum = await _albumService.GetById<Album>(ThisAlbumId);
            var tracksInAlbum = await _trackService.Get<List<Track>>(new TrackSearchRequest() { AlbumId = ThisAlbumId });
            foreach (var item in tracksInAlbum)
            {
                TrackPlusTrackNumber local = new TrackPlusTrackNumber()
                {
                    TrackId = item.TrackId,
                    Checked = false,
                    TrackNamePlusNumber = item.TrackNumber.ToString() + ". " + item.TrackName
                };
                TrackPlusTrackNumber local2 = new TrackPlusTrackNumber()
                {
                    TrackId = item.TrackId,
                    Checked = false,
                    TrackNamePlusNumber = item.TrackNumber.ToString() + ". " + item.TrackName
                };
                FavouriteTracksList.Add(local);
                LeastFavouriteTracksList.Add(local2);
            }
        }
        private void FavTrackChecked(int trackId)
        {
            var selected = FavouriteTracksList.Where(a => a.TrackId == trackId).FirstOrDefault();
            if (selected.Checked == true)
                selected.Checked = false;
            else selected.Checked = true;
        }
        private void LeastFavTrackChecked(int trackId)
        {
            var selected = LeastFavouriteTracksList.Where(a => a.TrackId == trackId).FirstOrDefault();
            if (selected.Checked == true)
                selected.Checked = false;
            else selected.Checked = true;
        }
        private bool ValidateEmpty()
        {
            if (string.IsNullOrWhiteSpace(ReviewText) || string.IsNullOrWhiteSpace(Rating))
                return false;
            return true;
        }
        private async Task<bool> ValidateReviewExists()
        {
            var returned = await _reviewService.Get<List<Review>>(new ReviewSearchRequest()
            {
                AlbumId = ThisAlbumId,
                UserId = APIService.loggedProfile.UserId
            });
            if (returned.Count > 0)
                return false;
            else return true;
        }
        private void SetFavProperties()
        {
            for (int i = 0; i < FavouriteTracksList.Count; i++)
            {
                if (FavouriteTracksList[i].Checked == true && LeastFavouriteTracksList[i].Checked == true)
                    continue;
                if (FavouriteTracksList[i].Checked == true)
                {
                    FavTracks += FavouriteTracksList[i].TrackNamePlusNumber;
                    FavTracks += ", ";
                }
                if (LeastFavouriteTracksList[i].Checked == true)
                {
                    LeastFavTracks += LeastFavouriteTracksList[i].TrackNamePlusNumber;
                    LeastFavTracks += ", ";
                }
            }
            if (FavTracks == "")
                FavTracks = "None";
            else
            {
                var NewFav = FavTracks.Substring(0, FavTracks.Length - 2);
                FavTracks = NewFav;
            }
            if (LeastFavTracks == "")
                LeastFavTracks = "None";
            else
            {
                var NewLeastFav = LeastFavTracks.Substring(0, LeastFavTracks.Length - 2);
                LeastFavTracks = NewLeastFav;
            }
        }
        private async Task SubmitReview()
        {
            if (!ValidateEmpty())
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill out the required fields (Review Text, Rating)", "OK");
                return;
            }
            bool v = await ValidateReviewExists();
            if (!v)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "You can't review the same album more than once!", "OK");
            }
            else
            {
                ReviewUpsertRequest request = new ReviewUpsertRequest()
                {
                    AlbumId = ThisAlbumId,
                    Rating = int.Parse(Rating),
                    ReviewText = ReviewText,
                    UserId = APIService.loggedProfile.UserId
                };
                SetFavProperties();
                request.FavouriteSongs = FavTracks;
                request.LeastFavouriteSongs = LeastFavTracks;
                var inserted = await _reviewService.Insert<Review>(request);
                await _postSerivce.Insert<Post>(new PostUpsertRequest()
                {
                    AdminName = APIService.loggedProfile.Username,
                    ArtistRelatedId = LoadedAlbum.ArtistId,
                    IsGlobal = false,
                    Opphoto = APIService.loggedProfile.UserPhoto,
                    PostDateTime = DateTime.Now,
                    PostPhoto = LoadedAlbum.AlbumPhoto,
                    PostText = ReviewText + "\n \n " + "Favorite tracks: " + FavTracks+"\n \n " + "Least favorite tracks: " + LeastFavTracks + "\n \n" + 
                    "Rating: " + Rating,
                    PostTitle = "Album Review: " +
                    LoadedAlbum.AlbumName,
                    ReviewRelatedId = inserted.ReviewId,
                    UserRelatedId = APIService.loggedProfile.UserId
                });
                await GlobalMethods.GenerateRating(ThisAlbumId);
                await Application.Current.MainPage.DisplayAlert("Success", "Review successfully added! You will now be redirected to the album page.", "OK");
                PopHandler?.Invoke(this, null);
            }
        }
    }
}
