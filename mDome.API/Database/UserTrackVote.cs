using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class UserTrackVote
    {
        public int UserId { get; set; }
        public int TrackId { get; set; }
        public bool Liked { get; set; }

        public virtual Track Track { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
