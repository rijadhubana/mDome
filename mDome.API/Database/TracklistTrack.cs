using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class TracklistTrack
    {
        public int TracklistId { get; set; }
        public int TrackId { get; set; }
        public DateTime? DateAdded { get; set; }

        public virtual Track Track { get; set; }
        public virtual Tracklist Tracklist { get; set; }
    }
}
