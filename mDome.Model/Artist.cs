using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string ArtistBio { get; set; }
        public string ArtistMembers { get; set; }
        public byte[] ArtistPhoto { get; set; }
        public byte[] ArtistPhotoThumb { get; set; }
    }
}
