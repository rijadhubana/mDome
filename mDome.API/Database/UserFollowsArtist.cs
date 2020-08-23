using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class UserFollowsArtist
    {
        public int UserId { get; set; }
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
