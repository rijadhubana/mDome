using mDome.MobileApp.Helper;
using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace mDome.MobileApp.ViewModels
{
    class FeaturedAlbumListsViewModel : BaseViewModel
    {
        private readonly APIService _userService = new APIService("UserProfile");
        private readonly APIService _albumListService = new APIService("AlbumList");
        private readonly APIService _albumListAlbumService = new APIService("AlbumListAlbum");
        public FeaturedAlbumListsViewModel()
        {
            InitCommand = new Command(async() => await Init());
        }
        public ICommand InitCommand { get; set; }
        public int UserId { get; set; }
        public ObservableCollection<AlbumListHelperVM> AlbumLists { get; set; } = new ObservableCollection<AlbumListHelperVM>();
        string _featuredAlbumLists;
        public string FeaturedAlbumLists
        {
            get
            {
                return _featuredAlbumLists;
            }

            set
            {
                _featuredAlbumLists = value;
                OnPropertyChanged("FeaturedAlbumLists");
            }
        }
        AlbumListHelperVM _selectedAlbumList;
        public AlbumListHelperVM SelectedAlbumList
        {
            get
            {
                return _selectedAlbumList;
            }

            set
            {
                _selectedAlbumList = value;
                OnPropertyChanged("SelectedAlbumList");
            }
        }
        private async Task Init()
        {
            var albumLists = await _albumListService.Get<List<AlbumList>>(new AlbumListSearchRequest() { UserId = UserId, AlbumListType = "Public" });
            var thisUser = await _userService.GetById<UserProfile>(UserId);
            foreach (var item in albumLists)
            {
                var numberofalbums = await _albumListAlbumService.Get<List<AlbumListAlbum>>(new AlbumListAlbumSearchRequest() { AlbumListId = item.AlbumListId });
                AlbumListHelperVM local = new AlbumListHelperVM()
                {
                    AlbumListId = item.AlbumListId,
                    AlbumListName = item.AlbumListName,
                    ListDateCreated = item.ListDateCreated,
                    UserId = thisUser.UserId,
                    Username = thisUser.Username,
                    NumberOfAlbums = "Number of albums: " + numberofalbums.Count.ToString()
                };
                AlbumLists.Add(local);
            }
            FeaturedAlbumLists = "Featured Album Lists by: " + thisUser.Username;
        }
    }
}
