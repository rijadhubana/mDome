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
    class GenreViewModel : BaseViewModel
    {
        private readonly APIService _artistService = new APIService("Artist");
        private readonly APIService _artistGenreService = new APIService("ArtistGenre");
        private readonly APIService _genreService = new APIService("Genre");
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _trackService = new APIService("Track");
        public GenreViewModel()
        {
            InitCommand = new Command(async() => await Init());
        }
        public ICommand InitCommand { get; set; }
        public int ThisGenreId { get; set; }
        Genre _loadedGenre;
        public Genre LoadedGenre
        {
            get
            {
                return _loadedGenre;
            }

            set
            {
                _loadedGenre = value;
                OnPropertyChanged("LoadedGenre");
            }
        }
        public ObservableCollectionFast<ArtistHelperVM> PopularArtistsList { get; set; } = new ObservableCollectionFast<ArtistHelperVM>();
        public ObservableCollectionFast<ArtistHelperVM> RandomArtistsList { get; set; } = new ObservableCollectionFast<ArtistHelperVM>();
        public List<TrackHelperVM> AllTracks { get; set; } = new List<TrackHelperVM>();
        public ObservableCollectionFast<TrackHelperVM> PopularTracks { get; set; } = new ObservableCollectionFast<TrackHelperVM>();
        public ObservableCollectionFast<TrackHelperVM> RandomTracks { get; set; } = new ObservableCollectionFast<TrackHelperVM>();

        private void LoadTracks()
        {
            PopularTracks.AddRange(AllTracks.OrderByDescending(a => (int)a.TrackViews).ToList().Take(5));
            RandomTracks.AddRange(AllTracks.OrderBy(a => Guid.NewGuid()).ToList().Take(5));
        }
        private async Task<int> LoadSumTrackViewsForArtist(int artistId)
        {
            var allAlbums = await _albumService.Get<List<Album>>(new AlbumSearchRequest() { ArtistId = artistId });
            int sum = 0;
            var thisArtist = await _artistService.GetById<Artist>(artistId);
            foreach (var item in allAlbums)
            {
                var thisAlbumTracks = await _trackService.Get<List<Track>>(new TrackSearchRequest() { AlbumId = item.AlbumId });
                sum += thisAlbumTracks.Sum(a => (int)a.TrackViews);
                foreach (var x in thisAlbumTracks)
                {
                    TrackHelperVM local = new TrackHelperVM()
                    {
                        AlbumId = item.AlbumId,
                        AlbumName = item.AlbumName,
                        ArtistId = thisArtist.ArtistId,
                        ArtistName = thisArtist.ArtistName,
                        TrackId = x.TrackId,
                        TrackName = x.TrackName,
                        TrackViews=(int)x.TrackViews
                    };
                    AllTracks.Add(local);
                }
            }
            return sum; 
        }
        private async Task LoadArtists()
        {
            var allArtists = await _artistService.Get<List<Artist>>(null);
            var allGenres = await _genreService.Get<List<Genre>>(null);
            var allArtistGenres = await _artistGenreService.Get<List<ArtistGenre>>(null);
            var helpList = allArtistGenres.Where(a => a.GenreId == ThisGenreId).ToList();
            List<Artist> artistFiltered = new List<Artist>();
            foreach (var item in helpList)
            {
                artistFiltered.Add(allArtists.Where(a => a.ArtistId == item.ArtistId).FirstOrDefault());
            }
            List<ArtistHelperVM> artistHelperVMs = new List<ArtistHelperVM>();
            foreach (var item in artistFiltered)
            {
                var genres = allArtistGenres.Where(a => a.ArtistId == item.ArtistId).ToList();
                string genresStr = "Genres: ";
                foreach (var x in genres)
                {
                    genresStr += allGenres.Where(a => a.GenreId == x.GenreId).Select(a => a.GenreName).FirstOrDefault();
                    if (x != genres.ElementAt(genres.Count - 1))
                        genresStr += ", ";
                }
                ArtistHelperVM local = new ArtistHelperVM()
                {
                    ArtistId = item.ArtistId,
                    ArtistMembers = item.ArtistMembers,
                    ArtistName = item.ArtistName,
                    ArtistPhoto = item.ArtistPhoto,
                    ArtistGenresInString=genresStr
                };
                local.SumTrackViews = await LoadSumTrackViewsForArtist(item.ArtistId);
                artistHelperVMs.Add(local);
            }
            var copyList = artistHelperVMs.OrderByDescending(a => a.SumTrackViews).ToList();
            PopularArtistsList.AddRange(copyList.Take(3));
            copyList = artistHelperVMs.OrderBy(a => Guid.NewGuid()).ToList();
            RandomArtistsList.AddRange(copyList.Take(3));
        }
        private async Task Init()
        {
            LoadedGenre = await _genreService.GetById<Genre>(ThisGenreId);
            await LoadArtists();
            LoadTracks();
        }

    }
}
