using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace mDome.MobileApp.ViewModels
{
    class MasterViewModel : BaseViewModel
    {
        Model.UserProfile current = APIService.loggedProfile;
        public MasterViewModel()
        {
            ProfilePhoto = current.UserPhoto;
            Wallpaper = current.UserWallpaper;
            Username = current.Username;
            Email = current.Email;
        }
        #region properties
        byte[] _profilePhoto;
        public byte[] ProfilePhoto
        {
            get
            {
                return _profilePhoto;
            }

            set
            {
                _profilePhoto = value;
                OnPropertyChanged("ProfilePhoto");
            }
        }
        byte[] _wallpaper;
        public byte[] Wallpaper
        {
            get
            {
                return _wallpaper;
            }

            set
            {
                _wallpaper = value;
                OnPropertyChanged("Wallpaper");
            }
        }
        string _username;
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
        string _email;
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
        string _selectedMenuItem;
        public string SelectedMenuItem
        {
            get
            {
                return _selectedMenuItem;
            }

            set
            {
                _selectedMenuItem = value;
                OnPropertyChanged("SelectedMenuItem");
            }
        }
        #endregion
    }
}
