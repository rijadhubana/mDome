using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string AlbumDescription { get; set; }
        public double? AlbumGeneratedRating { get; set; }
        public byte[] AlbumPhoto { get; set; }
        public byte[] AlbumPhotoThumb { get; set; }
        public int ArtistId { get; set; }
        public string DateReleased { get; set; }
    }
}
