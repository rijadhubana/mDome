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
    class TracklistPageViewModel : BaseViewModel
    {
        private readonly APIService _tracklistService = new APIService("Tracklist");
        private readonly APIService _tracklistTrackService = new APIService("TracklistTrack");
        private readonly APIService _trackService = new APIService("Track");
        private readonly APIService _userProfileService = new APIService("UserProfile");
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _artistService = new APIService("Artist");
        public TracklistPageViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SubmitChangesCommand = new Command(async () => await SubmitChanges());
            CopyTracklistCommand = new Command(async () => await CopyTracklist());
            DeleteTracklistCommand = new Command(async () => await DeleteTracklist());
        }
        public ICommand InitCommand { get; set; }
        public ICommand SubmitChangesCommand { get; set; }
        public ICommand CopyTracklistCommand { get; set; }
        public ICommand DeleteTracklistCommand { get; set; }
        public int ThisTracklistId { get; set; }
        Tracklist _loadedTracklist;
        public Tracklist LoadedTracklist
        {
            get
            {
                return _loadedTracklist;
            }

            set
            {
                _loadedTracklist = value;
                OnPropertyChanged("LoadedTracklist");
            }
        }
        UserProfile _loadedUserProfile;
        public UserProfile LoadedUserProfile
        {
            get
            {
                return _loadedUserProfile;
            }

            set
            {
                _loadedUserProfile = value;
                OnPropertyChanged("LoadedUserProfile");
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
        string _tracklistName;
        public string TracklistName
        {
            get
            {
                return _tracklistName;
            }

            set
            {
                _tracklistName = value;
                OnPropertyChanged("TracklistName");
            }
        }
        string _uniqueKey;
        public string UniqueKey
        {
            get
            {
                return _uniqueKey;
            }

            set
            {
                _uniqueKey = value;
                OnPropertyChanged("UniqueKey");
            }
        }
        bool _enableEntries;
        public bool EnableEntries
        {
            get
            {
                return _enableEntries;
            }

            set
            {
                _enableEntries = value;
                OnPropertyChanged("EnableEntries");
            }
        }
        bool _enableCopy;
        public bool EnableCopy
        {
            get
            {
                return _enableCopy;
            }

            set
            {
                _enableCopy = value;
                OnPropertyChanged("EnableCopy");
            }
        }
        string _selectedTracklistType;
        public string SelectedTracklistType
        {
            get
            {
                return _selectedTracklistType;
            }

            set
            {
                _selectedTracklistType = value;
                OnPropertyChanged("SelectedTracklistType");
            }
        }
        public ObservableCollection<TrackHelperVM> TracksInTracklist { get; set; } = new ObservableCollection<TrackHelperVM>();
        private async Task DeleteTracklist()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Confirm", "Are you sure you want to remove this tracklist?", "Yes", "No");
            if (answer == false)
                return;
            else
            {
                await _tracklistService.Delete<Tracklist>(ThisTracklistId);
                await Application.Current.MainPage.DisplayAlert("Success", "Tracklist successfully deleted! You will now be redirected to My Tracklists page.", "Ok");
                var aps = Application.Current.MainPage as MasterPage;
                await aps.MenuNavigate("My Tracklists/Album Lists");
            }
                   
        }
        private async Task SetWebViewSourceAndTracklistOnPage()
        {
            var ttr = await _tracklistTrackService.Get<List<TracklistTrack>>(new TracklistTrackSearchRequest() { TracklistId = ThisTracklistId });
            List<Track> TracksFromTracklist = new List<Track>();
            foreach (var item in ttr)
            {
                var thisTrack = await _trackService.GetById<Track>(item.TrackId);
                TracksFromTracklist.Add(thisTrack);
                var thisAlbum = await _albumService.GetById<Album>(thisTrack.AlbumId);
                var thisArtist = await _artistService.GetById<Artist>(thisAlbum.ArtistId);
                TrackHelperVM local = new TrackHelperVM()
                {
                    TrackId = thisTrack.TrackId,
                    TrackName = thisTrack.TrackName,
                    AlbumId = thisAlbum.AlbumId,
                    AlbumName = thisAlbum.AlbumName,
                    ArtistId = thisArtist.ArtistId,
                    ArtistName = thisArtist.ArtistName
                };
                TracksInTracklist.Add(local);
            }
            TracksFromTracklist = TracksFromTracklist.OrderBy(a => Guid.NewGuid()).ToList();
            WebViewSource = "https://www.youtube.com/embed/";
            if (TracksFromTracklist.Count!=0)
            {
                WebViewSource+= TracksFromTracklist.ElementAt(0).TrackYoutubeId + "?playlist=";
                foreach (var item in TracksFromTracklist)
                {
                    //skipping first track since it's already in the embed
                    if (item == TracksFromTracklist.ElementAt(0))
                        continue;
                    WebViewSource += item.TrackYoutubeId;
                    //skipping last element because of comma
                    if (item == TracksFromTracklist.ElementAt(TracksFromTracklist.Count - 1))
                        continue;
                    else WebViewSource += ",";
                }
            }
        }
        private bool ValidateEmpty()
        {
            if (string.IsNullOrWhiteSpace(UniqueKey) || string.IsNullOrWhiteSpace(TracklistName) || string.IsNullOrWhiteSpace(SelectedTracklistType))
                return false;
            return true;
        }
        private bool ValidateKeyLength()
        {
            if (UniqueKey.Length >= 20)
                return false;
            return true;
        }
        private bool ValidateName()
        {
            if (TracklistName == "History" || TracklistName == "My Discovery Queue" || TracklistName == "Liked Tracks")
                return false;
            return true;
        }
        private async Task CopyTracklist()
        {
            try
            {
                TracklistUpsertRequest request = new TracklistUpsertRequest()
                {
                    ListDateCreated = DateTime.Now,
                    UniqueKey = GlobalMethods.GenerateUniqueId(),
                    TracklistName = LoadedTracklist.TracklistName + " - Copied from " + LoadedUserProfile.Username,
                    TracklistType = "Private",
                    UserId = APIService.loggedProfile.UserId
                };
                var returned = await _tracklistService.Insert<Tracklist>(request);
                foreach (var item in TracksInTracklist)
                {
                    await _tracklistTrackService.Insert<TracklistTrack>(new TracklistTrackUpsertRequest()
                    {
                        DateAdded = DateTime.Now,
                        TrackId = item.TrackId,
                        TracklistId = returned.TracklistId
                    });
                }
                await Application.Current.MainPage.DisplayAlert("Success", "Tracklist successfully copied!", "OK");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");   
            }
        }
        private async Task SubmitChanges()
        {
            if (!ValidateEmpty())
                await Application.Current.MainPage.DisplayAlert("Error", "No empty fields allowed", "Ok");
            else if (!ValidateName())
                await Application.Current.MainPage.DisplayAlert("Error", "Tracklist name not allowed", "Ok");
            else if (!ValidateKeyLength())
                await Application.Current.MainPage.DisplayAlert("Error", "Maximum length of key is 20", "Ok");
            else
            {
                TracklistUpsertRequest request = new TracklistUpsertRequest()
                {
                    ListDateCreated = DateTime.Now,
                    TracklistName = TracklistName,
                    UniqueKey = UniqueKey,
                    UserId = APIService.loggedProfile.UserId,
                    TracklistType = SelectedTracklistType
                };
                var check = await _tracklistService.Get<List<Tracklist>>(new TracklistSearchRequest()
                {
                    TracklistName = TracklistName,
                    UniqueKey = UniqueKey
                });
                if (check.Where(a => a.TracklistId != ThisTracklistId).FirstOrDefault() != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Combination already exists. Please change the list name or unique key.", "OK");
                    return;
                }
                    await _tracklistService.Update<Tracklist>(ThisTracklistId, request);
                    await Application.Current.MainPage.DisplayAlert("Success", "Changes Submitted", "Ok");
            }

        }
        private async Task Init()
        {
            LoadedTracklist = await _tracklistService.GetById<Tracklist>(ThisTracklistId);
            LoadedUserProfile = await _userProfileService.GetById<UserProfile>(LoadedTracklist.UserId);
            if (LoadedTracklist.UserId == APIService.loggedProfile.UserId)
            {
                if (LoadedTracklist.TracklistName == "My Discovery Queue" || LoadedTracklist.TracklistName == "Liked Tracks"
                    || LoadedTracklist.TracklistName == "History")
                    EnableEntries = false;
                else EnableEntries = true;
                EnableCopy = false;
            }
                else 
            {
                EnableEntries = false;
                EnableCopy = !EnableEntries;
            }
            TracklistName = LoadedTracklist.TracklistName;
            UniqueKey = LoadedTracklist.UniqueKey;
            SelectedTracklistType = LoadedTracklist.TracklistType;
            await SetWebViewSourceAndTracklistOnPage();
        }


    }
}
