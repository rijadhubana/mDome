using mDome.MobileApp.Helper;
using mDome.MobileApp.ViewModels;
using mDome.MobileApp.Views;
using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Bluetooth.Advertisement;
using Xamarin.Forms;

namespace mDome.MobileApp.ViewModels
{
    class AlbumListViewModel : BaseViewModel
    {
        private readonly APIService _userService = new APIService("UserProfile");
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _artistService = new APIService("Artist");
        private readonly APIService _albumListService = new APIService("AlbumList");
        private readonly APIService _albumListAlbumService = new APIService("AlbumListAlbum");
        public AlbumListViewModel()
        {
            InitCommand = new Command(async () => await Init());
            CopyAlbumListCommand = new Command(async () => await CopyAlbumList());
            SubmitChangesCommand = new Command(async () => await SubmitChanges());
            DeleteAlbumListCommand = new Command(async () => await DeleteAlbumList());
        }
        public ICommand InitCommand { get; set; }
        public ICommand SubmitChangesCommand { get; set; }
        public ICommand DeleteAlbumListCommand { get; set; }
        public ICommand CopyAlbumListCommand { get; set; }
        public int ThisAlbumListId { get; set; }
        AlbumList _loadedAlbumList;
        public AlbumList LoadedAlbumList
        {
            get
            {
                return _loadedAlbumList;
            }

            set
            {
                _loadedAlbumList = value;
                OnPropertyChanged("LoadedAlbumList");
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
        string _albumListName;
        public string AlbumListName
        {
            get
            {
                return _albumListName;
            }

            set
            {
                _albumListName = value;
                OnPropertyChanged("AlbumListName");
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
        string _selectedAlbumListType;
        public string SelectedAlbumListType
        {
            get
            {
                return _selectedAlbumListType;
            }

            set
            {
                _selectedAlbumListType = value;
                OnPropertyChanged("SelectedAlbumListType");
            }
        }
        string _albumListDescription;
        public string AlbumListDescription
        {
            get
            {
                return _albumListDescription;
            }

            set
            {
                _albumListDescription = value;
                OnPropertyChanged("AlbumListDescription");
            }
        }

        public ObservableCollection<AlbumHelperVM> AlbumsInList { get; set; } = new ObservableCollection<AlbumHelperVM>();
        private async Task SetAlbums()
        {
            var albumListAlbums = await _albumListAlbumService.Get<List<AlbumListAlbum>>(new AlbumListAlbumSearchRequest()
            {
                AlbumListId = ThisAlbumListId
            });
            foreach (var item in albumListAlbums)
            {
                var thisAlbum = await _albumService.GetById<Album>(item.AlbumId);
                var thisArtist = await _artistService.GetById<Artist>(thisAlbum.ArtistId);
                AlbumHelperVM local = new AlbumHelperVM()
                {
                    ArtistId = thisAlbum.ArtistId,
                    AlbumId = thisAlbum.AlbumId,
                    AlbumGeneratedRating ="Rating: " + thisAlbum.AlbumGeneratedRating+"/5",
                    AlbumName = thisAlbum.AlbumName,
                    AlbumPhoto = thisAlbum.AlbumPhoto,
                    ArtistName = thisArtist.ArtistName,
                    DateReleased = thisAlbum.DateReleased
                };
                AlbumsInList.Add(local);
            }
        }
        private async Task CopyAlbumList()
        {
            try
            {
                AlbumListUpsertRequest request = new AlbumListUpsertRequest()
                {
                    ListDateCreated = DateTime.Now,
                    UniqueKey = GlobalMethods.GenerateUniqueId(),
                    AlbumListName = LoadedAlbumList.AlbumListName + " - Copied from " + LoadedUserProfile.Username,
                    AlbumListType = "Private",
                    UserId = APIService.loggedProfile.UserId,
                    AlbumListDescription=LoadedAlbumList.AlbumListDescription
                };
                var returned = await _albumListService.Insert<AlbumList>(request);
                foreach (var item in AlbumsInList)
                {
                    await _albumListAlbumService.Insert<AlbumListAlbum>(new AlbumListAlbumUpsertRequest()
                    {
                        AlbumId = item.AlbumId,
                        AlbumListId = returned.AlbumListId
                    });
                }
                await Application.Current.MainPage.DisplayAlert("Success", "Album list successfully copied!", "OK");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private bool ValidateEmpty()
        {
            if (string.IsNullOrWhiteSpace(UniqueKey) || string.IsNullOrWhiteSpace(AlbumListName) || string.IsNullOrWhiteSpace(SelectedAlbumListType))
                return false;
            return true;
        }
        private bool ValidateName()
        {
            if (AlbumListName == "Liked Albums")
                return false;
            return true;
        }
        private bool ValidateKeyLength()
        {
            if (UniqueKey.Length >= 20)
                return false;
            return true;
        }
        private async Task DeleteAlbumList()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Confirm", "Are you sure you want to remove this album list?", "Yes", "No");
            if (answer == false)
                return;
            else
            {
                await _albumListService.Delete<AlbumList>(ThisAlbumListId);
                await Application.Current.MainPage.DisplayAlert("Success", "Album list successfully deleted! You will now be redirected to My Tracklists/My Album Lists page.", "Ok");
                Application.Current.MainPage = new MasterPage(new NavigationPage(new MyTracklistsAlbumlistsPage()));
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
                AlbumListUpsertRequest request = new AlbumListUpsertRequest()
                {
                    ListDateCreated = DateTime.Now,
                    AlbumListName = AlbumListName,
                    UniqueKey = UniqueKey,
                    UserId = APIService.loggedProfile.UserId,
                    AlbumListType = SelectedAlbumListType,
                    AlbumListDescription=AlbumListDescription
                };
                try
                {
                    await _albumListService.Update<AlbumList>(ThisAlbumListId, request);
                    await Application.Current.MainPage.DisplayAlert("Success", "Changes Submitted", "Ok");
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                    return;
                }
            }

        }


        private async Task Init()
        {
            LoadedAlbumList = await _albumListService.GetById<AlbumList>(ThisAlbumListId);
            LoadedUserProfile = await _userService.GetById<UserProfile>(LoadedAlbumList.UserId);
            if (LoadedAlbumList.UserId == APIService.loggedProfile.UserId)
            {
                if (LoadedAlbumList.AlbumListName == "Liked Albums")
                    EnableEntries = false;
                else EnableEntries = true;
                EnableCopy = false;
            }
            else
            {
                EnableEntries = false;
                EnableCopy = !EnableEntries;
            }
            AlbumListName = LoadedAlbumList.AlbumListName;
            UniqueKey = LoadedAlbumList.UniqueKey;
            SelectedAlbumListType = LoadedAlbumList.AlbumListType;
            AlbumListDescription = LoadedAlbumList.AlbumListDescription;
            await SetAlbums();
        }
    }
}
