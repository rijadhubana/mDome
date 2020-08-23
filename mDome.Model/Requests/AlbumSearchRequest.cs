using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class AlbumSearchRequest
    {
        public string AlbumName { get; set; }
        public int? ArtistId { get; set; }
    }
}
