using mDome.MobileApp.Views;
using mDome.Model.Requests;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace mDome.MobileApp.ViewModels
{
    class AddPostViewModel : BaseViewModel
    {
        private readonly APIService _postService = new APIService("Post");
        public AddPostViewModel()
        {
            UploadImageCommand = new Command(async () => await UploadPostPhoto());
            PostImageSource = ImageSource.FromFile("wpplaceholder.png");
            PostPhoto = File.ReadAllBytes("wpplaceholder.png");
            SelectArtistCommand = new Command(async () => await SelectArtist());
            SubmitPostCommand = new Command(async () => await SubmitNewPost());
        }
        public ICommand UploadImageCommand { get; set; }
        public ICommand SelectArtistCommand { get; set; }
        public ICommand SubmitPostCommand { get; set; }
        public MediaFile _mediaFileWallpaper { get; set; }
        byte[] _postPhoto;
        public byte[] PostPhoto
        {
            get
            {
                return _postPhoto;
            }

            set
            {
                _postPhoto = value;
                OnPropertyChanged("PostPhoto");
            }
        }
        ImageSource _postImageSource;
        public ImageSource PostImageSource
        {
            get
            {
                return _postImageSource;
            }

            set
            {
                _postImageSource = value;
                OnPropertyChanged("PostImageSource");
            }
        }
        Model.Artist _placeholderArtist = new Model.Artist { ArtistName = "Artist", ArtistId = 0 };
        public Model.Artist PlaceholderArtist
        {
            get
            {
                return _placeholderArtist;
            }

            set
            {
                _placeholderArtist = value;
                OnPropertyChanged("PlaceholderArtist");
            }
        }
        string _postTitle="";
        public string PostTitle
        {
            get
            {
                return _postTitle;
            }

            set
            {
                _postTitle = value;
                OnPropertyChanged("PostTitle");
            }
        }
        string _postText="";
        public string PostText
        {
            get
            {
                return _postText;
            }

            set
            {
                _postText = value;
                OnPropertyChanged("PostText");
            }
        }

        private async Task UploadPostPhoto()
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
            PostPhoto = file;
            PostImageSource = ImageSource.FromStream(() => { return _mediaFileWallpaper.GetStream(); });
        }
        private async Task SelectArtist()
        {
            var popUp = new PopupArtists();
            popUp.CallbackEvent += (object sender, object e) =>
            {
                PlaceholderArtist = (Model.Artist)e;
            };
            await PopupNavigation.Instance.PushAsync(popUp);
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(PostText) || string.IsNullOrWhiteSpace(PostTitle))
                return false;
            return true;
        }
        private void RefreshFields()
        {
            PostText = "";
            PostTitle = "";
            PlaceholderArtist = new Model.Artist { ArtistId = 0, ArtistName = "Artist" };
            PostImageSource = ImageSource.FromFile("wpplaceholder.png");
            PostPhoto = File.ReadAllBytes("wpplaceholder.png");
        }
        private async Task SubmitNewPost()
        {
            if (ValidateFields())
            {
                PostUpsertRequest request = new PostUpsertRequest
                {
                    AdminName = APIService.Username,
                    IsGlobal = false,
                    UserRelatedId = APIService.loggedProfile.UserId,
                    Opphoto = APIService.loggedProfile.UserPhoto,
                    PostDateTime = DateTime.Now,
                    PostText = PostText,
                    PostTitle = PostTitle,
                    ReviewRelatedId = null,
                    PostPhoto = PostPhoto
                };
                if (PlaceholderArtist.ArtistId != 0)
                    request.ArtistRelatedId = PlaceholderArtist.ArtistId;
                else request.ArtistRelatedId = null;
                await _postService.Insert<Model.Post>(request);
                await Application.Current.MainPage.DisplayAlert("Success", "You have successfully added a post", "OK");
                RefreshFields();
            }
            else await Application.Current.MainPage.DisplayAlert("Error", "Post title and text cannot be empty", "OK");
        }
    }
}
