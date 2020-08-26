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
    class PopupAddToAlbumListViewModel : BaseViewModel
    {
        private readonly APIService _albumListService = new APIService("AlbumList");
        private readonly APIService _albumListAlbumService = new APIService("AlbumListAlbum");
        public PopupAddToAlbumListViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SearchCommand = new Command<string>(Search);
        }
        public ICommand InitCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public int ThisAlbumId { get; set; }
        public ObservableCollection<AlbumList> AllAlbumLists { get; set; } = new ObservableCollection<AlbumList>();
        public ObservableCollection<AlbumList> AlbumLists { get; set; } = new ObservableCollection<AlbumList>();
        AlbumList _selectedAlbumList;
        public AlbumList SelectedAlbumList
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
        private void Search(string searchQuery)
        {
            AlbumLists.Clear();
            foreach (var item in AllAlbumLists)
            {
                if (item.AlbumListName.ToLower().Contains(searchQuery.ToLower()))
                    AlbumLists.Add(item);
            }
        }
        private async Task Init()
        {
            var returned = await _albumListService.Get<List<AlbumList>>(new AlbumListSearchRequest() { UserId = APIService.loggedProfile.UserId });
            returned.Remove(returned.Where(a => a.AlbumListName == "Liked Albums").FirstOrDefault());
            foreach (var item in returned)
            {
                var tracks = await _albumListAlbumService.Get<List<AlbumListAlbum>>(new AlbumListAlbumSearchRequest()
                { AlbumListId = item.AlbumListId });
                if (tracks.Where(a=>a.AlbumId == ThisAlbumId).FirstOrDefault()==null)
                {
                    AllAlbumLists.Add(item);
                    AlbumLists.Add(item);
                }

            }

        }
    }
}
