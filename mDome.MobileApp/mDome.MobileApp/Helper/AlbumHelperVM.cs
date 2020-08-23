using mDome.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.MobileApp.Helper
{
    public class AlbumHelperVM
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string AlbumGeneratedRating { get; set; }
        public byte[] AlbumPhoto { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string DateReleased { get; set; }
    }
}
