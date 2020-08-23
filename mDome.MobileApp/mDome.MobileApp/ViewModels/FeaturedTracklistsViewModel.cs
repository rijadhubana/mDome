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
    class FeaturedTracklistsViewModel : BaseViewModel
    {
        private readonly APIService _tracklistService = new APIService("Tracklist");
        private readonly APIService _tracklistTrackService = new APIService("TracklistTrack");
        private readonly APIService _userService = new APIService("UserProfile");

        public FeaturedTracklistsViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ICommand InitCommand { get; set; }
        public int UserId { get; set; }
        public ObservableCollection<TracklistHelperVM> Tracklists { get; set; } = new ObservableCollection<TracklistHelperVM>();
        string _featuredTracklists;
        public string FeaturedTracklists
        {
            get
            {
                return _featuredTracklists;
            }

            set
            {
                _featuredTracklists = value;
                OnPropertyChanged("FeaturedTracklists");
            }
        }
        TracklistHelperVM _selectedTracklist;
        public TracklistHelperVM SelectedTrackList
        {
            get
            {
                return _selectedTracklist;
            }

            set
            {
                _selectedTracklist = value;
                OnPropertyChanged("SelectedTrackList");
            }
        }
        private async Task Init()
        {
            var tracklists = await _tracklistService.Get<List<Tracklist>>(new TracklistSearchRequest() { UserId = UserId, TracklistType="Public" });
            var thisUser = await _userService.GetById<UserProfile>(UserId);
            foreach (var item in tracklists)
            {
                var numberoftracks = await _tracklistTrackService.Get<List<TracklistTrack>>(new TracklistTrackSearchRequest() { TracklistId = item.TracklistId });
                TracklistHelperVM local = new TracklistHelperVM()
                {
                    TracklistId = item.TracklistId,
                    ListDateCreated = item.ListDateCreated,
                    NumberOfTracks = "Number of tracks: " + numberoftracks.Count.ToString(),
                    TracklistName = item.TracklistName,
                    UserId = thisUser.UserId,
                    Username = thisUser.Username
                };
                Tracklists.Add(local);
            }
            FeaturedTracklists = "Featured Tracklists by: " + thisUser.Username;
        }
    }
}
