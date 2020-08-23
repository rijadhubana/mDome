using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class UserAlbumVote
    {
        public int UserId { get; set; }
        public int AlbumId { get; set; }
        public bool Liked { get; set; }
    }
}
