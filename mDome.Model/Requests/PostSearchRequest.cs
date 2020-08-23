using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class PostSearchRequest
    {
        public int? UserRelatedId { get; set; }
        public int? ArtistRelatedId { get; set; }
        public bool? IsGlobal { get; set; }
        public int? ReviewRelatedId { get; set; }
    }
}
