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
    class AddOrRemoveTracksViewModel : BaseViewModel
    {
        private readonly APIService _tracklistTrackService = new APIService("TracklistTrack");
        private readonly APIService _trackService = new APIService("Track");
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _artistService = new APIService("Artist");
        public AddOrRemoveTracksViewModel()
        {
            InitCommand = new Command(async () => await Init());
            ClickedCommand = new Command(async () => await Clicked());
            SearchCommandTracks = new Command<string>(async (x) => await SearchTracks(x));
        }
        public ICommand InitCommand { get; set; }
        public ICommand ClickedCommand { get; set; }
        public ICommand SearchCommandTracks { get; set; }
        bool _addTracks;
        public bool AddTracks
        {
            get
            {
                return _addTracks;
            }

            set
            {
                _addTracks = value;
                OnPropertyChanged("AddTracks");
            }
        }
        public int TracklistId { get; set; }
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
        private async Task Clicked()
        {
            TracklistTrackUpsertRequest req = new TracklistTrackUpsertRequest()
            {
                DateAdded = DateTime.Now,
                TrackId = SelectedTrack.TrackId,
                TracklistId = TracklistId
            };
            try
            {
                if (AddTracks == true)
                {

                    await _tracklistTrackService.Insert<TracklistTrack>(req);
                }
                else
                {
                    await _tracklistTrackService.Update<TracklistTrack>(0, req);
                }
                Tracks.Remove(SelectedTrack);
                AllTracks.Remove(SelectedTrack);
                SelectedTrack = null;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            
        }
        private async Task SearchTracks(string searchQuery)
        {
            if (AddTracks==true)
            {
                if (string.IsNullOrWhiteSpace(searchQuery))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Please type in the search bar", "OK");
                    return;
                }
                var searchResult = await _trackService.Get<List<Track>>(new TrackSearchRequest() { TrackName = searchQuery });
                Tracks.Clear();
                foreach (var item in searchResult)
                {
                    var thisTrack = await _trackService.GetById<Track>(item.TrackId);
                    var thisAlbum = await _albumService.GetById<Album>(thisTrack.AlbumId);
                    var thisArtist = await _artistService.GetById<Artist>(thisAlbum.ArtistId);
                    TrackHelperVM local = new TrackHelperVM()
                    {
                        TrackId = thisTrack.TrackId,
                        TrackName = thisTrack.TrackName,
                        AlbumId = thisAlbum.AlbumId,
                        AlbumName = thisAlbum.AlbumName,
                        ArtistId = thisArtist.ArtistId,
                        ArtistName = thisArtist.ArtistName
                    };
                    Tracks.Add(local);
                }
            }
            else
            {
                Tracks.Clear();
                foreach (var item in AllTracks)
                {
                    if (item.TrackName.ToLower().Contains(searchQuery.ToLower()))
                        Tracks.Add(item);
                }
            }
            
        }
        private async Task Init()
        {
           var tracksintracklist = await _tracklistTrackService.Get<List<TracklistTrack>>(new TracklistTrackSearchRequest() { TracklistId = TracklistId });
           if (AddTracks==false)
            {
                foreach (var item in tracksintracklist)
                {
                    var thisTrack = await _trackService.GetById<Track>(item.TrackId);
                    var thisAlbum = await _albumService.GetById<Album>(thisTrack.AlbumId);
                    var thisArtist = await _artistService.GetById<Artist>(thisAlbum.ArtistId);
                    TrackHelperVM local = new TrackHelperVM()
                    {
                        TrackId = thisTrack.TrackId,
                        TrackName = thisTrack.TrackName,
                        AlbumId = thisAlbum.AlbumId,
                        AlbumName = thisAlbum.AlbumName,
                        ArtistId = thisArtist.ArtistId,
                        ArtistName = thisArtist.ArtistName
                    };
                    Tracks.Add(local);
                    AllTracks.Add(local);
                }
            }
        }
    }
}
