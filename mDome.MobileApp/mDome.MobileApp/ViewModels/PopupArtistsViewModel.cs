using mDome.MobileApp.Helper;
using mDome.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace mDome.MobileApp.ViewModels
{
    class PopupArtistsViewModel : BaseViewModel
    {
        private readonly APIService _artistService = new APIService("Artist");
        public PopupArtistsViewModel()
        {
            GetArtistsCommand = new Command(async() => await  GetArtists());
            SearchCommand = new Command<string>(SearchArtists);
            GetArtistsCommand.Execute(null);
        }
        ArtistHelperVM selectedArtistPriv;
        public ArtistHelperVM selectedArtist
        {
            get
            {
                return selectedArtistPriv;
            }

            set
            {
                selectedArtistPriv = value;
                OnPropertyChanged("selectedArtist");
            }
        }
        public ObservableCollection<ArtistHelperVM> artists { get; set; } = new ObservableCollection<ArtistHelperVM>();
        public List<Model.Artist> allArtists { get; set; }
        public ICommand GetArtistsCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public async Task GetArtists()
        {
            allArtists = await _artistService.Get<List<Model.Artist>>(null);
            foreach (var item in allArtists)
            {
                artists.Add(new ArtistHelperVM() { ArtistId = item.ArtistId, ArtistMembers = item.ArtistMembers, ArtistName = item.ArtistName });
            }
        }
        public void SearchArtists(string searchQuery)
        {
            artists.Clear();
            foreach (var item in allArtists)
            {
                if (item.ArtistName.ToLower().Contains(searchQuery.ToLower()) || item.ArtistMembers.ToLower().Contains(searchQuery.ToLower()))
                {
                    artists.Add(new ArtistHelperVM() { ArtistId = item.ArtistId, ArtistMembers = item.ArtistMembers, ArtistName = item.ArtistName });
                }
            }
        }
    }
}
