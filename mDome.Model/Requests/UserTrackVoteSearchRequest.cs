using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class UserTrackVoteSearchRequest
    {
        public int? UserId { get; set; }
        public int? TrackId { get; set; }
        public bool? Liked { get; set; }
    }
}
