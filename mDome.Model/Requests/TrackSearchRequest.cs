using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class TrackSearchRequest
    {
        public string TrackName { get; set; }
        public int? AlbumId { get; set; }
    }
}
