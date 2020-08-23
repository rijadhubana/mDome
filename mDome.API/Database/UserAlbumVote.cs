using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class UserAlbumVote
    {
        public int UserId { get; set; }
        public int AlbumId { get; set; }
        public bool Liked { get; set; }

        public virtual Album Album { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
