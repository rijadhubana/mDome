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
    class AllArtistsViewModel : BaseViewModel
    {
        private readonly APIService _artistService = new APIService("Artist");
        private readonly APIService _artistGenreService = new APIService("ArtistGenre");
        private readonly APIService _genreService = new APIService("Genre");
        public AllArtistsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ICommand InitCommand { get; set; }
        public int ThisGenreId { get; set; }
        public Genre LoadedGenre { get; set; }
        public ObservableCollection<ArtistHelperVM> Artists { get; set; } = new ObservableCollection<ArtistHelperVM>();
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
        string _headerText;
        public string HeaderText
        {
            get
            {
                return _headerText;
            }

            set
            {
                _headerText = value;
                OnPropertyChanged("HeaderText");
            }
        }
        private async Task Init()
        {
            var allArtistsReturned = await _artistService.Get<List<Model.Artist>>(null);
            var allGenres = await _genreService.Get<List<Genre>>(null);
            LoadedGenre = allGenres.Where(a => a.GenreId == ThisGenreId).FirstOrDefault();
            HeaderText = "Artists from genre: " + LoadedGenre.GenreName;
            var allArtistGenre = await _artistGenreService.Get<List<Model.ArtistGenre>>(new ArtistGenreSearchRequest()
            { GenreId=ThisGenreId});
            List<Artist> filteredArtist = new List<Artist>();
            foreach (var item in allArtistGenre)
            {
                filteredArtist.Add(allArtistsReturned.Where(a => a.ArtistId == item.ArtistId).First());
            }
            foreach (var item in filteredArtist)
            {
                var genres = allArtistGenre.Where(a => a.ArtistId == item.ArtistId).ToList();
                string genresStr = "Genres: ";
                foreach (var x in genres)
                {
                    genresStr += allGenres.Where(a => a.GenreId == x.GenreId).Select(a => a.GenreName).FirstOrDefault();
                    if (x != genres.ElementAt(genres.Count - 1))
                        genresStr += ", ";
                }
                Artists.Add(new ArtistHelperVM()
                {
                    ArtistGenresInString = genresStr,
                    ArtistId = item.ArtistId,
                    ArtistMembers = item.ArtistMembers,
                    ArtistName = item.ArtistName,
                    ArtistPhoto = item.ArtistPhoto
                });
            }
        }
    }
}
