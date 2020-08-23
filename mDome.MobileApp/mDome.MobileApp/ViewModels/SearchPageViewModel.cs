using mDome.MobileApp.Helper;
using mDome.MobileApp.Views;
using mDome.Model;
using mDome.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace mDome.MobileApp.ViewModels
{
    class SearchPageViewModel : BaseViewModel
    {
        private readonly APIService _artistService = new APIService("Artist");
        private readonly APIService _genreService = new APIService("Genre");
        private readonly APIService _artistGenreService = new APIService("ArtistGenre");
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _userService = new APIService("UserProfile");
        private readonly APIService _trackService = new APIService("Track");
        private readonly APIService _tracklistService = new APIService("Tracklist");
        private readonly APIService _tracklistTrackService = new APIService("TracklistTrack");
        private readonly APIService _albumListService = new APIService("AlbumList");
        private readonly APIService _albumListAlbumService = new APIService("AlbumListAlbum");

        public SearchPageViewModel()
        {
            InitCommand = new Command(async () => await Init());
            InitCommand.Execute(null);
            SearchCommandArtists = new Command<string>(SearchArtists);
            SearchCommandAlbums = new Command<string>(SearchAlbums);
            SearchCommandTracks = new Command<string>(SearchTracks);
            SearchCommandGenres = new Command<string>(SearchGenres);
            SearchCommandUsers = new Command<string>(SearchUsers);
            SearchCommandTracklists = new Command<string>(SearchTracklists);
            SearchCommandAlbumLists = new Command<string>(SearchAlbumLists);
            AccessPrivateTracklistCommand = new Command(async () => await AccessPrivateTracklist());
            AccessPrivateAlbumListCommand = new Command(async () => await AccessPrivateAlbumList());

        }
        public ICommand InitCommand { get; set; }
        public ICommand SearchCommandArtists { get; set; }
        public ICommand SearchCommandAlbums { get; set; }
        public ICommand SearchCommandTracks { get; set; }
        public ICommand SearchCommandGenres { get; set; }
        public ICommand SearchCommandUsers { get; set; }
        public ICommand SearchCommandTracklists { get; set; }
        public ICommand SearchCommandAlbumLists { get; set; }
        public ICommand AccessPrivateTracklistCommand { get; set; }
        public ICommand AccessPrivateAlbumListCommand { get; set; }
        public ObservableCollection<ArtistHelperVM> AllArtists { get; set; } = new ObservableCollection<ArtistHelperVM>();
        public ObservableCollection<ArtistHelperVM> QueryArtists { get; set; } = new ObservableCollection<ArtistHelperVM>();
        public ObservableCollection<Genre> AllGenres { get; set; } = new ObservableCollection<Genre>();
        public ObservableCollection<Genre> QueryGenres { get; set; } = new ObservableCollection<Genre>();
        public ObservableCollection<AlbumHelperVM> AllAlbums { get; set; } = new ObservableCollection<AlbumHelperVM>();
        public ObservableCollection<AlbumHelperVM> QueryAlbums { get; set; } = new ObservableCollection<AlbumHelperVM>();
        public ObservableCollection<UserProfile> AllUsers { get; set; } = new ObservableCollection<UserProfile>();
        public ObservableCollection<UserProfile> QueryUsers { get; set; } = new ObservableCollection<UserProfile>();
        public ObservableCollection<TrackHelperVM> AllTracks { get; set; } = new ObservableCollection<TrackHelperVM>();
        public ObservableCollection<TrackHelperVM> QueryTracks { get; set; } = new ObservableCollection<TrackHelperVM>();
        public ObservableCollection<TracklistHelperVM> AllTracklists { get; set; } = new ObservableCollection<TracklistHelperVM>();
        public ObservableCollection<TracklistHelperVM> QueryTracklists { get; set; } = new ObservableCollection<TracklistHelperVM>();
        public ObservableCollection<AlbumListHelperVM> AllAlbumLists { get; set; } = new ObservableCollection<AlbumListHelperVM>();
        public ObservableCollection<AlbumListHelperVM> QueryAlbumLists { get; set; } = new ObservableCollection<AlbumListHelperVM>();

        ArtistHelperVM _selectedArtist;
        public ArtistHelperVM SelectedArtist
        {
            get
            {
                return _selectedArtist;
            }

            set
            {
                _selectedArtist = value;
                OnPropertyChanged("SelectedArtist");
            }
        }
        Genre _selectedGenre;
        public Genre SelectedGenre
        {
            get
            {
                return _selectedGenre;
            }

            set
            {
                _selectedGenre = value;
                OnPropertyChanged("SelectedGenre");
            }
        }
        AlbumHelperVM _selectedAlbum;
        public AlbumHelperVM SelectedAlbum
        {
            get
            {
                return _selectedAlbum;
            }

            set
            {
                _selectedAlbum = value;
                OnPropertyChanged("SelectedAlbum");
            }
        }
        UserProfile _selectedUser;
        public UserProfile SelectedUser
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
        TrackHelperVM _selectedTrack;
        public TrackHelperVM SelectedTrack
        {
            get
            {
                return _selectedTrack;
            }

            set
            {
                _selectedTrack = value;
                OnPropertyChanged("SelectedTrack");
            }
        }
        TracklistHelperVM _selectedTracklist;
        public TracklistHelperVM SelectedTracklist
        {
            get
            {
                return _selectedTracklist;
            }

            set
            {
                _selectedTracklist = value;
                OnPropertyChanged("SelectedTracklist");
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
        public int accessTracklistNumber { get; set; }
        public int accessAlbumListNumber { get; set; }
        private async Task Init()
        {
            await LoadArtistsAndGenres();
            await LoadAlbums();
            await LoadUsers();
            await LoadTracks();
            await LoadTracklists();
            await LoadAlbumLists();
        }
        private async Task LoadArtistsAndGenres()
        {
            var allArtistsReturned = await _artistService.Get<List<Model.Artist>>(null);
            var allGenres = await _genreService.Get<List<Model.Genre>>(null);
            var allArtistGenre = await _artistGenreService.Get<List<Model.ArtistGenre>>(null);
            foreach (var item in allArtistsReturned)
            {
                var genres = allArtistGenre.Where(a => a.ArtistId == item.ArtistId).ToList();
                string genresStr = "Genres: ";
                foreach (var x in genres)
                {
                    genresStr += allGenres.Where(a => a.GenreId == x.GenreId).Select(a => a.GenreName).FirstOrDefault();
                    if (x != genres.ElementAt(genres.Count - 1))
                        genresStr += ", ";
                }
                AllArtists.Add(new ArtistHelperVM()
                {
                    ArtistGenresInString = genresStr,
                    ArtistId = item.ArtistId,
                    ArtistMembers = item.ArtistMembers,
                    ArtistName = item.ArtistName,
                    ArtistPhoto = item.ArtistPhoto
                });
                QueryArtists.Add(new ArtistHelperVM()
                {
                    ArtistGenresInString = genresStr,
                    ArtistId = item.ArtistId,
                    ArtistMembers = item.ArtistMembers,
                    ArtistName = item.ArtistName,
                    ArtistPhoto = item.ArtistPhoto
                });
            }
            foreach (var item in allGenres)
            {
                AllGenres.Add(item);
                QueryGenres.Add(item);
            }
        }
        private async Task LoadAlbums()
        {
            var allAlbums = await _albumService.Get<List<Model.Album>>(null);
            foreach (var item in allAlbums)
            {
                AlbumHelperVM local = new AlbumHelperVM()
                {
                    AlbumGeneratedRating = "Rating: " + item.AlbumGeneratedRating.ToString() + "/5",
                    AlbumId = item.AlbumId,
                    AlbumName = item.AlbumName,
                    AlbumPhoto = item.AlbumPhoto,
                    ArtistId = item.ArtistId,
                    DateReleased = "Released: " + item.DateReleased
                };
                local.ArtistName = AllArtists.Where(a => a.ArtistId == local.ArtistId).Select(a => a.ArtistName).FirstOrDefault();
                AllAlbums.Add(local);
                QueryAlbums.Add(local);
            }
        }
        private async Task LoadUsers()
        {
            var usersReturned = await _userService.Get<List<Model.UserProfile>>(null);
            foreach (var item in usersReturned)
            {
                AllUsers.Add(item);
                QueryUsers.Add(item);
            }
        }
        private async Task LoadTracks()
        {
            var tracksReturned = await _trackService.Get<List<Model.Track>>(null);
            foreach (var item in tracksReturned)
            {
                TrackHelperVM local = new TrackHelperVM()
                {
                    TrackId = item.TrackId,
                    TrackName = item.TrackName,
                    AlbumName = AllAlbums.Where(a => a.AlbumId == item.AlbumId).Select(a => a.AlbumName).FirstOrDefault(),
                    AlbumId=item.AlbumId
                };
                local.ArtistId = AllAlbums.Where(a => a.AlbumId == local.AlbumId).Select(a => a.ArtistId).FirstOrDefault();
                local.ArtistName = AllArtists.Where(a => a.ArtistId == local.ArtistId).Select(a => a.ArtistName).FirstOrDefault();
                AllTracks.Add(local);
                QueryTracks.Add(local);
            }
        }
        private async Task LoadTracklists()
        {
            var tracklistsReturned = await _tracklistService.Get<List<Model.Tracklist>>(new TracklistSearchRequest() { TracklistType = "Public" });
            var tracklistTracksReturned = await _tracklistTrackService.Get<List<Model.TracklistTrack>>(null);
            foreach (var item in tracklistsReturned)
            {
                TracklistHelperVM local = new TracklistHelperVM()
                {
                    ListDateCreated = item.ListDateCreated,
                    TracklistName = item.TracklistName,
                    UserId = item.UserId,
                    TracklistId=item.TracklistId
                };
                local.Username ="By: " + AllUsers.Where(a => a.UserId == local.UserId).Select(a => a.Username).FirstOrDefault();
                local.NumberOfTracks ="Number of tracks: " + tracklistTracksReturned.Where(a => a.TracklistId == local.TracklistId).Count().ToString();
                AllTracklists.Add(local);
                QueryTracklists.Add(local);
            }
        }
        private async Task LoadAlbumLists()
        {
            var albumListsReturned = await _albumListService.Get<List<Model.AlbumList>>(new AlbumListSearchRequest() { AlbumListType = "Public" });
            var albumListAlbumReturned = await _albumListAlbumService.Get<List<Model.AlbumListAlbum>>(null);
            foreach (var item in albumListsReturned)
            {
                AlbumListHelperVM local = new AlbumListHelperVM()
                {
                    AlbumListId = item.AlbumListId,
                    AlbumListName = item.AlbumListName,
                    ListDateCreated = item.ListDateCreated,
                    UserId = item.UserId
                };
                local.Username = "By: " + AllUsers.Where(a => a.UserId == local.UserId).Select(a => a.Username).FirstOrDefault();
                local.NumberOfAlbums = "Number of albums: " + albumListAlbumReturned.Where(a => a.AlbumListId == local.AlbumListId).Count().ToString();
                AllAlbumLists.Add(local);
                QueryAlbumLists.Add(local);
            }
        }
        private void SearchArtists(string searchQuery)
        {
            QueryArtists.Clear();
            foreach (var item in AllArtists)
            {
                if (item.ArtistName.ToLower().Contains(searchQuery.ToLower()) ||
                    item.ArtistMembers.ToLower().Contains(searchQuery.ToLower()))
                    QueryArtists.Add(item);
            }
        }
        private void SearchAlbums(string searchQuery)
        {
            QueryAlbums.Clear();
            foreach (var item in AllAlbums)
            {
                if (item.AlbumName.ToLower().Contains(searchQuery.ToLower()))
                    QueryAlbums.Add(item);
            }
        }
        private void SearchTracks(string searchQuery)
        {
            QueryTracks.Clear();
            foreach (var item in AllTracks)
            {
                if (item.TrackName.ToLower().Contains(searchQuery.ToLower()))
                    QueryTracks.Add(item);
            }
        }
        private void SearchGenres(string searchQuery)
        {
            QueryGenres.Clear();
            foreach (var item in AllGenres)
            {
                if (item.GenreName.ToLower().Contains(searchQuery.ToLower()))
                    QueryGenres.Add(item);
            }
        }
        private void SearchUsers(string searchQuery)
        {
            QueryUsers.Clear();
            foreach (var item in AllUsers)
            {
                if (item.Username.ToLower().Contains(searchQuery.ToLower()))
                    QueryUsers.Add(item);
            }
        }
        private void SearchTracklists(string searchQuery)
        {
            QueryTracklists.Clear();
            foreach (var item in AllTracklists)
            {
                if (item.TracklistName.ToLower().Contains(searchQuery.ToLower()))
                    QueryTracklists.Add(item);
            }
        }
        private void SearchAlbumLists(string searchQuery)
        {
            QueryAlbumLists.Clear();
            foreach (var item in AllAlbumLists)
            {
                if (item.AlbumListName.ToLower().Contains(searchQuery.ToLower()))
                    QueryAlbumLists.Add(item);
            }
        }
        public event EventHandler<object> AccessTracklistEventHandler;
        public event EventHandler<object> AccessAlbumListEventHandler;
        private async Task AccessPrivateTracklist()
        {
            string tracklistName = await Application.Current.MainPage.DisplayPromptAsync("Tracklist name", "Please type in the tracklist name.");
            if (string.IsNullOrWhiteSpace(tracklistName))
                return;
            string tracklistKey = await Application.Current.MainPage.DisplayPromptAsync("Unique key", "Now type in the unique key for the tracklist.");
            if (string.IsNullOrWhiteSpace(tracklistKey))
                return;
            var returned = await _tracklistService.Get<List<Tracklist>>(new TracklistSearchRequest()
            {
                TracklistName = tracklistName,
                TracklistType = "Private",
                UniqueKey = tracklistKey
            });
            if (returned.Count==0)
                accessTracklistNumber = 0;
            else
                accessTracklistNumber = returned.First().TracklistId;
            AccessTracklistEventHandler?.Invoke(this, accessTracklistNumber);
        }
        private async Task AccessPrivateAlbumList()
        {
            string albumListName = await Application.Current.MainPage.DisplayPromptAsync("Album list name", "Please type in the album list name.");
            if (string.IsNullOrWhiteSpace(albumListName))
                return;
            string albumListKey = await Application.Current.MainPage.DisplayPromptAsync("Unique key", "Now type in the unique key for the album list.");
            if (string.IsNullOrWhiteSpace(albumListKey))
                return;
            var returned = await _albumListService.Get<List<AlbumList>>(new AlbumListSearchRequest()
            {
                AlbumListName = albumListName,
                AlbumListType = "Private",
                UniqueKey = albumListKey
            });
            if (returned.Count == 0)
            {
                accessAlbumListNumber = 0;
            }
            else
            {
                accessAlbumListNumber = returned.First().AlbumListId;
            }
            AccessAlbumListEventHandler?.Invoke(this, accessAlbumListNumber);
        }
        




    }
}
