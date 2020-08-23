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
    class AllTracksViewModel : BaseViewModel
    {
        private readonly APIService _trackService = new APIService("Track");
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _artistService = new APIService("Artist");

        public AllTracksViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SearchCommandTracks = new Command<string>(SearchTracks);
        }
        public ICommand InitCommand { get; set; }
        public ICommand SearchCommandTracks { get; set; }
        public int ThisArtistId { get; set; }
        public ObservableCollection<TrackHelperVM> Tracks { get; set; } = new ObservableCollection<TrackHelperVM>();
        public ObservableCollection<TrackHelperVM> AllTracks { get; set; } = new ObservableCollection<TrackHelperVM>();

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
        private void SearchTracks(string searchQuery)
        {
            Tracks.Clear();
            foreach (var item in AllTracks)
            {
                if (item.TrackName.ToLower().Contains(searchQuery.ToLower()))
                    Tracks.Add(item);
            }
        }
        private async Task Init()
        {
            var returned = await _albumService.Get<List<Album>>(new AlbumSearchRequest() { ArtistId = ThisArtistId });
            var thisArtist = await _artistService.GetById<Artist>(ThisArtistId);
            foreach (var item in returned)
            {
                var tracksInAlbum = await _trackService.Get<List<Track>>(new TrackSearchRequest() { AlbumId = item.AlbumId });
                foreach (var x in tracksInAlbum)
                {
                    TrackHelperVM local = new TrackHelperVM()
                    {
                        AlbumId = item.AlbumId,
                        AlbumName = item.AlbumName,
                        ArtistId = ThisArtistId,
                        ArtistName = thisArtist.ArtistName,
                        TrackId = x.TrackId,
                        TrackName = x.TrackName
                    };
                    Tracks.Add(local);
                    AllTracks.Add(local);
                }
            }
        }
    }
}
