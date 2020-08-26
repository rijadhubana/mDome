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
    class PopupAddToTracklistViewModel : BaseViewModel
    {
        private readonly APIService _tracklistService = new APIService("Tracklist");
        private readonly APIService _tracklistTrackService = new APIService("TracklistTrack");
        public PopupAddToTracklistViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SearchCommand = new Command<string>(Search);
        }
        public ICommand InitCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public int ThisTrackId { get; set; }
        public ObservableCollection<Tracklist> AllTracklists { get; set; } = new ObservableCollection<Tracklist>();
        public ObservableCollection<Tracklist> Tracklists { get; set; } = new ObservableCollection<Tracklist>();
        Tracklist _selectedTracklist;
        public Tracklist SelectedTracklist
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
        private void Search(string searchQuery)
        {
            Tracklists.Clear();
            foreach (var item in AllTracklists)
            {
                if (item.TracklistName.ToLower().Contains(searchQuery.ToLower()))
                    Tracklists.Add(item);
            }
        }
        private async Task Init()
        {
            var returned = await _tracklistService.Get<List<Tracklist>>(new TracklistSearchRequest() { UserId = APIService.loggedProfile.UserId });
            returned.Remove(returned.Where(a => a.TracklistName == "Liked Tracks").FirstOrDefault());
            returned.Remove(returned.Where(a => a.TracklistName == "My Discovery Queue").FirstOrDefault());
            returned.Remove(returned.Where(a => a.TracklistName == "History").FirstOrDefault());
            foreach (var item in returned)
            {
                var tracks = await _tracklistTrackService.Get<List<TracklistTrack>>(new TracklistTrackSearchRequest() { TracklistId = item.TracklistId });
                if (tracks.Where(a=>a.TrackId == ThisTrackId).FirstOrDefault()==null)
                {
                    AllTracklists.Add(item);
                    Tracklists.Add(item);
                }

            }

        }
    }
}
