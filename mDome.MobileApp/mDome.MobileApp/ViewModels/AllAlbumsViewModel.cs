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
    class AllAlbumsViewModel : BaseViewModel
    {
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _artistService = new APIService("Artist");
        public AllAlbumsViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SearchCommandAlbums = new Command<string>(SearchAlbums);
        }
        public ICommand SearchCommandAlbums { get; set; }
        public ICommand InitCommand { get; set; }
        public int ThisArtistId { get; set; }
        public ObservableCollection<AlbumHelperVM> Albums { get; set; } = new ObservableCollection<AlbumHelperVM>();
        public ObservableCollection<AlbumHelperVM> AllAlbums { get; set; } = new ObservableCollection<AlbumHelperVM>();

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
        private void SearchAlbums(string searchQuery)
        {
                Albums.Clear();
                foreach (var item in AllAlbums)
                {
                    if (item.AlbumName.ToLower().Contains(searchQuery.ToLower()))
                        Albums.Add(item);
                }
        }
        private async Task Init()
        {
            var returned = await _albumService.Get<List<Album>>(new AlbumSearchRequest() { ArtistId = ThisArtistId });
            foreach (var item in returned)
            {
                var thisArtist = await _artistService.GetById<Artist>(item.ArtistId);
                AlbumHelperVM local = new AlbumHelperVM()
                {
                    ArtistId = item.ArtistId,
                    AlbumGeneratedRating = "Rating: " + item.AlbumGeneratedRating + "/5",
                    AlbumId = item.AlbumId,
                    AlbumName = item.AlbumName,
                    AlbumPhoto = item.AlbumPhoto,
                    ArtistName = thisArtist.ArtistName,
                    DateReleased = item.DateReleased
                };
                Albums.Add(local);
                AllAlbums.Add(local);
            }
        }

    }
}
