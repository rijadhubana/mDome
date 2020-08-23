using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class TrackUpsertRequest
    {
        [Required(AllowEmptyStrings =false)]
        public string TrackName { get; set; }
        public int? TrackViews { get; set; }
        [Required]
        public string TrackYoutubeId { get; set; }
        public string TrackLyrics { get; set; }
        [Required]
        public int AlbumId { get; set; }
        public int? TrackNumber { get; set; }
    }
}
