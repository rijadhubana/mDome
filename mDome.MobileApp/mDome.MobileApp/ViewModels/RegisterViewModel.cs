using mDome.MobileApp.Converters;
using mDome.MobileApp.Helper;
using mDome.MobileApp.Views;
using mDome.Model;
using mDome.Model.Requests;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace mDome.MobileApp.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {
        readonly APIService _albumService = new APIService("Album");
        readonly APIService _artistService = new APIService("Artist");
        readonly APIService _userService = new APIService("UserProfile");
        readonly APIService _tracklistService = new APIService("Tracklist");
        readonly APIService _albumListService = new APIService("AlbumList");
        readonly APIService _administratorLoginService = new APIService("AdministratorLogin");
        public RegisterViewModel()
        {
            APIService.Username = "user";
            APIService.Password = "user";
            BackToLoginCommand = new Command(BackToLogin);
            UploadProfileCommand = new Command(async () => await UploadProfilePicture());
            UploadWallpaperCommand = new Command(async () => await UploadWallpaper());
            ProfilePhotoSource = ImageSource.FromFile("profile.png");
            ProfilePhoto = File.ReadAllBytes("profile.png");
            WallpaperSource = ImageSource.FromFile("wpplaceholder.png");
            Wallpaper = File.ReadAllBytes("wallpaper.png");
            PopUpSearchAlbumsCommand = new Command<string>(async (x) => await PopUpAlbums(x));
            PopUpSearchArtistsCommand = new Command<string>(async (x) => await PopUpArtists(x));
            SubmitRegistrationCommand = new Command(async () => await SubmitRegistration());
            EditProfileCommand = new Command(async () => await EditProfileSetProperties());
        }
        public ICommand BackToLoginCommand { get; set; }
        public ICommand UploadProfileCommand { get; set; }
        public ICommand UploadWallpaperCommand { get; set; }
        public ICommand PopUpSearchAlbumsCommand { get; set; }
        public ICommand PopUpSearchArtistsCommand { get; set; }
        public ICommand SubmitRegistrationCommand { get; set; }
        public ICommand EditProfileCommand { get; set; }

        #region requestProperties
        string _username = string.Empty;
        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
        string _email = string.Empty;

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        string _about = string.Empty;

        public string About
        {
            get
            {
                return _about;
            }

            set
            {
                _about = value;
                OnPropertyChanged("About");
            }
        }
        ImageSource _profilePhotoSource;
        public ImageSource ProfilePhotoSource
        {
            get
            {
                return _profilePhotoSource;
            }

            set
            {
                _profilePhotoSource = value;
                OnPropertyChanged("ProfilePhotoSource");
            }
        }
        ImageSource _wallpaperSource;
        public ImageSource WallpaperSource
        {
            get
            {
                return _wallpaperSource;
            }

            set
            {
                _wallpaperSource = value;
                OnPropertyChanged("WallpaperSource");
            }
        }
        public byte[] ProfilePhoto { get; set; }
        public byte[] Wallpaper { get; set; }
        Model.Album _album1 = new Model.Album() { AlbumName = "Album 1",AlbumId=0 };
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
        Model.Album _album2 = new Model.Album() { AlbumName = "Album 2",AlbumId = 0 };
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
        Model.Album _album3 = new Model.Album() { AlbumName = "Album 3", AlbumId = 0 };
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
        Model.Artist _artist1 = new Model.Artist() { ArtistName = "Artist 1", ArtistId = 0 };
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
        Model.Artist _artist2 = new Model.Artist() { ArtistName = "Artist 2", ArtistId = 0 };
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
        Model.Artist _artist3 = new Model.Artist() { ArtistName = "Artist 3", ArtistId = 0 };
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
        string _password = string.Empty;

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        string _passwordConfirm = string.Empty;

        public string PasswordConfirm
        {
            get
            {
                return _passwordConfirm;
            }

            set
            {
                _passwordConfirm = value;
                OnPropertyChanged("PasswordConfirm");
            }
        }
        #endregion
        private MediaFile _mediaFileProfilePhoto;
        private MediaFile _mediaFileWallpaper;
        public Model.Album placeholderAlbum;
        public Model.Artist placeholderArtist;
        public bool EditProfile { get; set; }
        bool _enableUsernameEmail = true;
        public bool EnableUsernameEmail
        {
            get
            {
                return _enableUsernameEmail;
            }

            set
            {
                _enableUsernameEmail = value;
                OnPropertyChanged("EnableUsernameEmail");
            }
        }

        private async Task EditProfileSetProperties()
        {
            Username = APIService.loggedProfile.Username;
            Email = APIService.loggedProfile.Email;
            About = APIService.loggedProfile.About;
            if (APIService.loggedProfile.RecommendedAlbum1.HasValue)
                Album1 = await _albumService.GetById<Model.Album>(APIService.loggedProfile.RecommendedAlbum1);
            if (APIService.loggedProfile.RecommendedAlbum2.HasValue)
                Album2 = await _albumService.GetById<Model.Album>(APIService.loggedProfile.RecommendedAlbum2);
            if (APIService.loggedProfile.RecommendedAlbum3.HasValue)
                Album3 = await _albumService.GetById<Model.Album>(APIService.loggedProfile.RecommendedAlbum3);
            if (APIService.loggedProfile.RecommendedArtist1.HasValue)
                Artist1 = await _artistService.GetById<Model.Artist>(APIService.loggedProfile.RecommendedArtist1);
            if (APIService.loggedProfile.RecommendedArtist2.HasValue)
                Artist2 = await _artistService.GetById<Model.Artist>(APIService.loggedProfile.RecommendedArtist2);
            if (APIService.loggedProfile.RecommendedArtist3.HasValue)
                Artist3 = await _artistService.GetById<Model.Artist>(APIService.loggedProfile.RecommendedArtist3);
            ProfilePhoto = APIService.loggedProfile.UserPhoto;
            Wallpaper = APIService.loggedProfile.UserWallpaper;
            ProfilePhotoSource = ImageSource.FromStream(() => new MemoryStream(ProfilePhoto));
            WallpaperSource = ImageSource.FromStream(() => new MemoryStream(Wallpaper));
            EnableUsernameEmail = false;

        }
        private async Task UploadProfilePicture()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }
            _mediaFileProfilePhoto = await CrossMedia.Current.PickPhotoAsync();
            if (_mediaFileProfilePhoto == null)
                return;
            var path = _mediaFileProfilePhoto.Path;
            var file = File.ReadAllBytes(path);
            ProfilePhoto = file;
            ProfilePhotoSource = ImageSource.FromStream(() => { return _mediaFileProfilePhoto.GetStream(); });

        }
        
        private async Task PopUpAlbums(string buttonNumber)
        {
            var popUp = new PopupAlbums();
            popUp.CallbackEvent += (object sender, object e) => 
            {
                placeholderAlbum = (Model.Album)e;
                if ((placeholderAlbum.AlbumId==Album1.AlbumId&&placeholderAlbum.AlbumName!="Not Selected") || 
                (placeholderAlbum.AlbumId==Album2.AlbumId && placeholderAlbum.AlbumName != "Not Selected") || 
                (placeholderAlbum.AlbumId==Album3.AlbumId && placeholderAlbum.AlbumName != "Not Selected"))
                    Application.Current.MainPage.DisplayAlert("Error","You can't feature an album more than once!",  "OK");
                else
                {
                    if (int.Parse(buttonNumber) == 1)
                        Album1 = placeholderAlbum;
                    else if (int.Parse(buttonNumber) == 2)
                        Album2 = placeholderAlbum;
                    else if (int.Parse(buttonNumber) == 3)
                        Album3 = placeholderAlbum;
                }
                
            };
            await PopupNavigation.Instance.PushAsync(popUp);
        }
        private async Task PopUpArtists(string buttonNumber)
        {
            var popUp = new PopupArtists();
            popUp.CallbackEvent += (object sender, object e) =>
            {
                placeholderArtist = (Model.Artist)e;
                if ((placeholderArtist.ArtistId == Artist1.ArtistId&&placeholderArtist.ArtistName!="Not Selected") ||
                (placeholderArtist.ArtistId == Artist2.ArtistId&& placeholderArtist.ArtistName != "Not Selected") || 
                (placeholderArtist.ArtistId == Artist3.ArtistId && placeholderArtist.ArtistName != "Not Selected"))
                    Application.Current.MainPage.DisplayAlert("Error", "You can't feature an artist more than once!", "OK");
                else
                {
                    if (int.Parse(buttonNumber) == 1)
                        Artist1 = placeholderArtist;
                    else if (int.Parse(buttonNumber) == 2)
                        Artist2 = placeholderArtist;
                    else if (int.Parse(buttonNumber) == 3)
                        Artist3 = placeholderArtist;
                }
            };
            await PopupNavigation.Instance.PushAsync(popUp);
        }
        private async Task UploadWallpaper()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }
            _mediaFileWallpaper = await CrossMedia.Current.PickPhotoAsync();
            if (_mediaFileWallpaper == null)
                return;
            var path = _mediaFileWallpaper.Path;
            var file = File.ReadAllBytes(path);
            Wallpaper = file;
            WallpaperSource = ImageSource.FromStream(() => { return _mediaFileWallpaper.GetStream(); });
        }
        private void BackToLogin()
        {
            Application.Current.MainPage = new LoginPage();
        }
        private bool ValidateEmptyFields()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(PasswordConfirm))
                return false;
            return true;
        }
        private bool ValidatePasswordMatch()
        {
            if (Password != PasswordConfirm)
                return false;
            return true;
        }
        private void SetRecommended(UserProfileUpsertRequest request)
        {
            if (_album1.AlbumId != 0)
                request.RecommendedAlbum1 = _album1.AlbumId;
            else request.RecommendedAlbum1 = null;
            if (_album2.AlbumId != 0)
                request.RecommendedAlbum2 = _album2.AlbumId;
            else request.RecommendedAlbum2 = null;
            if (_album1.AlbumId != 0)
                request.RecommendedAlbum3 = _album3.AlbumId;
            else request.RecommendedAlbum3 = null;
            if (_artist1.ArtistId != 0)
                request.RecommendedArtist1 = _artist1.ArtistId;
            else request.RecommendedArtist1 = null;
            if (_artist2.ArtistId != 0)
                request.RecommendedArtist2 = _artist2.ArtistId;
            else request.RecommendedArtist2 = null;
            if (_artist3.ArtistId != 0)
                request.RecommendedArtist3 = _artist3.ArtistId;
            else request.RecommendedArtist3 = null;

        }
        private string GenerateUniqueId()
        {
            var newGuid = Guid.NewGuid();
            var messageID = Convert.ToBase64String(newGuid.ToByteArray());
            return messageID.Substring(0,18);
        }
        private async Task GenerateTracklists(int userId)
        {
            //Generating history, discoveryqueue, liked tracks, liked albums for new account 
            await _tracklistService.Insert<Model.Tracklist>(new TracklistUpsertRequest()
            {
                ListDateCreated = DateTime.Now,
                TracklistName = "History",
                TracklistType = "Private",
                UniqueKey = GenerateUniqueId(),
                UserId = userId
            });
            await _tracklistService.Insert<Model.Tracklist>(new TracklistUpsertRequest()
            {
                ListDateCreated = DateTime.Now,
                TracklistName = "My Discovery Queue",
                TracklistType = "Private",
                UniqueKey = GenerateUniqueId(),
                UserId = userId
            });
            await _tracklistService.Insert<Model.Tracklist>(new TracklistUpsertRequest()
            {
                ListDateCreated = DateTime.Now,
                TracklistName = "Liked Tracks",
                TracklistType = "Private",
                UniqueKey = GenerateUniqueId(),
                UserId = userId
            });
            await _albumListService.Insert<Model.AlbumList>(new AlbumListUpsertRequest()
            {
                ListDateCreated = DateTime.Now,
                AlbumListDescription = "",
                AlbumListName = "Liked Albums",
                AlbumListType = "Private",
                UniqueKey = GenerateUniqueId(),
                UserId = userId
            });
        }
        private async Task SubmitRegistration()
        {
            if (ValidateEmptyFields()==false)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill out the required fields (Username,Email,Password,Password Confirmation)", "OK");
                return;
            }
            if (ValidatePasswordMatch()==false)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match", "OK");
                return;
            }
                    var request = new UserProfileUpsertRequest()
                    {
                        Username = _username,
                        About = _about,
                        Email = _email,
                        PasswordClearText = _password,
                        PasswordClearTextConfirm = _passwordConfirm,
                        RegisteredAt = DateTime.Now,
                        SuspendedFlag = false,
                        UserPhoto = ProfilePhoto,
                        UserWallpaper = Wallpaper
                    };
                    SetRecommended(request);
                if (EditProfile==true)
                {
                    request.RegisteredAt = APIService.loggedProfile.RegisteredAt;
                    await _userService.Update<Model.UserProfile>(APIService.loggedProfile.UserId,request);
                    await Application.Current.MainPage.DisplayAlert("Success", "Profile updated! Please relog for the actions to take change", "OK");

                }
                else
                {
                    var check = await _userService.Get<List<UserProfile>>(new UserProfileSearchRequest() { Username = request.Username, Email=request.Email });
                    var check2 = await _administratorLoginService.Get<List<AdministratorLogin>>(new AdminSearchRequest() { AdminName=request.Username});
                    if (check.Count>0 || check2.Count>0)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Username already taken!", "OK");
                        return;
                    }
                    var returnedUser = await _userService.Insert<Model.UserProfile>(request);
                    await GenerateTracklists(returnedUser.UserId);
                    await Application.Current.MainPage.DisplayAlert("Success", "You have successfully registered your account! You will now be redirected to login page.", "OK");
                }
                APIService.loggedProfile = null;
                APIService.Username = "";
                APIService.Password = "";
                Application.Current.MainPage = new LoginPage();
            }
        }
}

