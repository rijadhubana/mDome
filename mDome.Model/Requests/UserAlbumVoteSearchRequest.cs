using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class UserAlbumVoteSearchRequest
    {
        public int? UserId { get; set; }
        public int? AlbumId { get; set; }
        public bool? Liked { get; set; }
    }
}
