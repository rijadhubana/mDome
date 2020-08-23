using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class Track
    {
        public Track()
        {
            TracklistTrack = new HashSet<TracklistTrack>();
            UserTrackVote = new HashSet<UserTrackVote>();
        }

        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public int? TrackViews { get; set; }
        public string TrackYoutubeId { get; set; }
        public string TrackLyrics { get; set; }
        public int AlbumId { get; set; }
        public int? TrackNumber { get; set; }

        public virtual Album Album { get; set; }
        public virtual ICollection<TracklistTrack> TracklistTrack { get; set; }
        public virtual ICollection<UserTrackVote> UserTrackVote { get; set; }
    }
}
