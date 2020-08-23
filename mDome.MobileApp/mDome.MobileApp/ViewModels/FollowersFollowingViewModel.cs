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
using Xamarin.Forms;

namespace mDome.MobileApp.ViewModels
{
    class FollowersFollowingViewModel : BaseViewModel
    {
        private readonly APIService _userService = new APIService("UserProfile");
        private readonly APIService _userFollowersService = new APIService("UserFollowers");
        public FollowersFollowingViewModel()
        {
            UserId = APIService.loggedProfile.UserId;
            InitCommand = new Command(async () => await Init());
            InitCommand.Execute(null);
        }
        public ICommand InitCommand { get; set; }
        public int UserId { get; set; }
        string _followersNumber;
        public string FollowersNumber
        {
            get
            {
                return _followersNumber;
            }

            set
            {
                _followersNumber = value;
                OnPropertyChanged("FollowersNumber");
            }
        }
        string _followingNumber;
        public string FollowingNumber
        {
            get
            {
                return _followingNumber;
            }

            set
            {
                _followingNumber = value;
                OnPropertyChanged("FollowingNumber");
            }
        }
        public ObservableCollection<UserProfile> Followers { get; set; } = new ObservableCollection<UserProfile>();
        public ObservableCollection<UserProfile> Following { get; set; } = new ObservableCollection<UserProfile>();
        Model.UserProfile _selectedUser;
        public Model.UserProfile SelectedUser
        {
            get
            {
                return _selectedUser;
            }

            set
            {
                _selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        private async Task Init()
        {
            var followers = await _userFollowersService.Get<List<Model.UserFollowers>>(new UserFollowersSearchRequest() { UserId=APIService.loggedProfile.UserId});
            var following  = await _userFollowersService.Get<List<Model.UserFollowers>>(new UserFollowersSearchRequest() { FollowedByUserId = APIService.loggedProfile.UserId });
            foreach (var item in followers)
            {
                Followers.Add(await _userService.GetById<Model.UserProfile>(item.FollowedByUserId));
            }
            foreach (var item in following)
            {
                Following.Add(await _userService.GetById<Model.UserProfile>(item.UserId));
            }
            FollowersNumber = "Followers: " + followers.Count().ToString();
            FollowingNumber = "Following: " + following.Count().ToString();
        }


    }
}
