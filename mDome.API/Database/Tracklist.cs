using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class Tracklist
    {
        public Tracklist()
        {
            TracklistTrack = new HashSet<TracklistTrack>();
        }

        public int TracklistId { get; set; }
        public string TracklistName { get; set; }
        public DateTime ListDateCreated { get; set; }
        public int UserId { get; set; }
        public string UniqueKey { get; set; }
        public string TracklistType { get; set; }

        public virtual UserProfile User { get; set; }
        public virtual ICollection<TracklistTrack> TracklistTrack { get; set; }
    }
}
