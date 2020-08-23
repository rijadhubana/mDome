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
    class AddOrRemoveAlbumsViewModel : BaseViewModel
    {
        private readonly APIService _albumListAlbumService = new APIService("AlbumListAlbum");
        private readonly APIService _albumService = new APIService("Album");
        private readonly APIService _artistService = new APIService("Artist");
        public AddOrRemoveAlbumsViewModel()
        {
            ClickedCommand = new Command(async () => await Clicked());
            InitCommand = new Command(async () => await Init());
            SearchCommandAlbums = new Command<string>(async (x) => await SearchAlbums(x));
        }
        public ICommand InitCommand { get; set; }
        public ICommand ClickedCommand { get; set; }
        public ICommand SearchCommandAlbums { get; set; }
        bool _addAlbums;
        public bool AddAlbums
        {
            get
            {
                return _addAlbums;
            }

            set
            {
                _addAlbums = value;
                OnPropertyChanged("AddAlbums");
            }
        }
        public int AlbumListId { get; set; }
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
        private async Task Clicked()
        {
            AlbumListAlbumUpsertRequest req = new AlbumListAlbumUpsertRequest()
            {
                AlbumId = SelectedAlbum.AlbumId,
                AlbumListId = AlbumListId
            };
            try
            {
                if (AddAlbums == true)
                {

                    await _albumListAlbumService.Insert<AlbumListAlbum>(req);
                }
                else
                {
                    await _albumListAlbumService.Update<AlbumListAlbum>(0, req);
                }
                Albums.Remove(SelectedAlbum);
                AllAlbums.Remove(SelectedAlbum);
                SelectedAlbum = null;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

        }
        private async Task SearchAlbums(string searchQuery)
        {
            if (AddAlbums == true)
            {
                if (string.IsNullOrWhiteSpace(searchQuery))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Please type in the search bar", "OK");
                    return;
                }
                var searchResult = await _albumService.Get<List<Album>>(new AlbumSearchRequest() { AlbumName = searchQuery });
                Albums.Clear();
                foreach (var item in searchResult)
                {
                    var thisArtist = await _artistService.GetById<Artist>(item.ArtistId);
                    AlbumHelperVM local = new AlbumHelperVM()
                    {
                        AlbumId = item.AlbumId,
                        AlbumName = item.AlbumName,
                        ArtistId = thisArtist.ArtistId,
                        ArtistName = thisArtist.ArtistName,
                        AlbumGeneratedRating = "Rating: " + item.AlbumGeneratedRating.ToString() + "/5",
                        AlbumPhoto = item.AlbumPhoto,
                        DateReleased = item.DateReleased
                    };
                    Albums.Add(local);
                }
            }
            else
            {
                Albums.Clear();
                foreach (var item in AllAlbums)
                {
                    if (item.AlbumName.ToLower().Contains(searchQuery.ToLower()))
                        Albums.Add(item);
                }
            }

        }
        private async Task Init()
        {
            var albumsinlist = await _albumListAlbumService.Get<List<AlbumListAlbum>>(new AlbumListAlbumSearchRequest() { AlbumListId = AlbumListId });
            if (AddAlbums == false)
            {
                foreach (var item in albumsinlist)
                {
                    var thisAlbum = await _albumService.GetById<Album>(item.AlbumId);
                    var thisArtist = await _artistService.GetById<Artist>(thisAlbum.ArtistId);
                    AlbumHelperVM local = new AlbumHelperVM()
                    {
                        AlbumId = thisAlbum.AlbumId,
                        AlbumName = thisAlbum.AlbumName,
                        ArtistId = thisArtist.ArtistId,
                        ArtistName = thisArtist.ArtistName,
                        AlbumGeneratedRating="Rating: " + thisAlbum.AlbumGeneratedRating.ToString()+"/5",
                        AlbumPhoto=thisAlbum.AlbumPhoto, DateReleased=thisAlbum.DateReleased
                    };
                    Albums.Add(local);
                    AllAlbums.Add(local);
                }
            }
        }



    }

}
