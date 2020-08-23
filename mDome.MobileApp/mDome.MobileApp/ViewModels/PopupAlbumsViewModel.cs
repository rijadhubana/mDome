using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using mDome.MobileApp;
using System.Linq;
using mDome.MobileApp.Helper;

namespace mDome.MobileApp.ViewModels
{
    class PopupAlbumsViewModel : BaseViewModel
    {
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _artistService = new APIService("Artist");

        public PopupAlbumsViewModel()
        {
            APIService.Password = "Rikeyhhh";
            APIService.Username = "Rikeyhhh";
            GetAlbumsCommand = new Command(async () => await GetAlbums());
            GetAlbumsCommand.Execute(null);
            SearchCommand = new Command<string>(SearchAlbums);
        }
        AlbumPlusArtist selectedAlbumPriv;
        public AlbumPlusArtist selectedAlbum
        {
            get
            {
                return selectedAlbumPriv;
            }

            set
            {
                selectedAlbumPriv = value;
                OnPropertyChanged("selectedAlbum");
            }
        }
        public ObservableCollection<AlbumPlusArtist> albums { get; set; } = new ObservableCollection<AlbumPlusArtist>();
        public List<Model.Artist> allArtists { get; set; }
        public List<Model.Album> allAlbums { get; set; }
        public ICommand GetAlbumsCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public async Task GetAlbums()
        {
            allAlbums = await _albumService.Get<List<Model.Album>>(null);
            allArtists = await _artistService.Get<List<Model.Artist>>(null);
            foreach (var item in allAlbums)
            {
                albums.Add(new AlbumPlusArtist
                {
                    AlbumId = item.AlbumId,
                    AlbumName = item.AlbumName,
                    ArtistName = allArtists.Where(a => a.ArtistId == item.ArtistId).Select(a => a.ArtistName).FirstOrDefault()
                });
            }
        }
        public void SearchAlbums(string searchQuery)
        {
            albums.Clear();
            foreach (var item in allAlbums)
            {
                if (item.AlbumName.ToLower().Contains(searchQuery.ToLower()))
                {
                    albums.Add(new AlbumPlusArtist
                    {
                        AlbumId = item.AlbumId,
                        AlbumName = item.AlbumName,
                        ArtistName = allArtists.Where(a => a.ArtistId == item.ArtistId).Select(a => a.ArtistName).FirstOrDefault()
                    });
                }
            }
        }
    }
}
