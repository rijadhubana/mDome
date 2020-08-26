using mDome.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.MobileApp.Helper
{
    public class TrackHelperVM
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int TrackViews { get; set; }
    }
}
