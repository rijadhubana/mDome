using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class AlbumUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string AlbumName { get; set; }
        public string AlbumDescription { get; set; }
        public double? AlbumGeneratedRating { get; set; }
        public byte[] AlbumPhoto { get; set; }
        public byte[] AlbumPhotoThumb { get; set; }
        [Required]
        public int ArtistId { get; set; }
        public string DateReleased { get; set; }
    }
}
