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
    class MyTracklistsAlbumListsViewModel : BaseViewModel
    {
        private readonly APIService _tracklistService = new APIService("Tracklist");
        private readonly APIService _albumListService = new APIService("AlbumList");
        private readonly APIService _albumListAlbumService = new APIService("AlbumListAlbum");
        private readonly APIService _tracklistTrackService = new APIService("TracklistTrack");

        public MyTracklistsAlbumListsViewModel()
        {
            InitCommand = new Command(async () => await Init());
            InitCommand.Execute(null);
            SearchCommandAlbumLists = new Command<string>(SearchAlbumLists);
            SearchCommandTracklists = new Command<string>(SearchTracklists);
        }
        public ICommand InitCommand { get; set; }
        public ICommand SearchCommandAlbumLists { get; set; }
        public ICommand SearchCommandTracklists { get; set; }
        public ObservableCollection<AlbumListHelperVM> MyAlbumLists { get; set; } = new ObservableCollection<AlbumListHelperVM>();
        public ObservableCollection<AlbumListHelperVM> QueryAlbumLists { get; set; } = new ObservableCollection<AlbumListHelperVM>();
        public ObservableCollection<TracklistHelperVM> MyTracklists { get; set; } = new ObservableCollection<TracklistHelperVM>();
        public ObservableCollection<TracklistHelperVM> QueryTracklists { get; set; } = new ObservableCollection<TracklistHelperVM>();
        TracklistHelperVM _selectedTracklist;
        public TracklistHelperVM SelectedTrackList
        {
            get
            {
                return _selectedTracklist;
            }

            set
            {
                _selectedTracklist = value;
                OnPropertyChanged("SelectedTrackList");
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

        private void SearchTracklists(string searchQuery)
        {
            QueryTracklists.Clear();
            foreach (var item in MyTracklists)
            {
                if (item.TracklistName.ToLower().Contains(searchQuery.ToLower()))
                    QueryTracklists.Add(item);
            }
        }
        private void SearchAlbumLists(string searchQuery)
        {
            QueryAlbumLists.Clear();
            foreach (var item in MyAlbumLists)
            {
                if (item.AlbumListName.ToLower().Contains(searchQuery.ToLower()))
                    QueryAlbumLists.Add(item);
            }
        }

        private async Task Init()
        {
            var albumlists = await _albumListService.Get<List<AlbumList>>(new AlbumListSearchRequest() { UserId = APIService.loggedProfile.UserId });
            var tracklists = await _tracklistService.Get<List<Tracklist>>(new TracklistSearchRequest() { UserId = APIService.loggedProfile.UserId });
            foreach (var item in albumlists)
            {
                var numberofalbums = await _albumListAlbumService.Get<List<AlbumListAlbum>>(new AlbumListAlbumSearchRequest() { AlbumListId = item.AlbumListId });
                AlbumListHelperVM local = new AlbumListHelperVM()
                {
                    AlbumListId = item.AlbumListId,
                    AlbumListName = item.AlbumListName,
                    ListDateCreated = item.ListDateCreated,
                    UserId = APIService.loggedProfile.UserId,
                    Username = APIService.loggedProfile.Username,
                    NumberOfAlbums = "Number of albums: " + numberofalbums.Count.ToString()
                };
                MyAlbumLists.Add(local);
                QueryAlbumLists.Add(local);
            }
            foreach (var item in tracklists)
            {
                var numberoftracks = await _tracklistTrackService.Get<List<TracklistTrack>>(new TracklistTrackSearchRequest() { TracklistId = item.TracklistId });
                TracklistHelperVM local = new TracklistHelperVM()
                {
                    TracklistId = item.TracklistId,
                    ListDateCreated = item.ListDateCreated,
                    NumberOfTracks = "Number of tracks: " + numberoftracks.Count.ToString(),
                    TracklistName = item.TracklistName,
                    UserId = APIService.loggedProfile.UserId,
                    Username = APIService.loggedProfile.Username
                };
                MyTracklists.Add(local);
                QueryTracklists.Add(local);
            }
        }
    }
}
