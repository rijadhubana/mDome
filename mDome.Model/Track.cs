using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class Track
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public int? TrackViews { get; set; }
        public string TrackYoutubeId { get; set; }
        public string TrackLyrics { get; set; }
        public int AlbumId { get; set; }
        public int? TrackNumber { get; set; }
    }
}
