using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class UserFollowsArtistSearchRequest
    {
        public int? UserId { get; set; }
        public int? ArtistId { get; set; }
    }
}
