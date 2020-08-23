using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class UserTrackVote
    {
        public int UserId { get; set; }
        public int TrackId { get; set; }
        public bool Liked { get; set; }
    }
}
