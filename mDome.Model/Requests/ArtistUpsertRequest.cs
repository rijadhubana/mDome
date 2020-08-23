using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class ArtistUpsertRequest
    {
        [Required(AllowEmptyStrings =false)]
        public string ArtistName { get; set; }
        public string ArtistBio { get; set; }
        public string ArtistMembers { get; set; }
        public byte[] ArtistPhoto { get; set; }
        public byte[] ArtistPhotoThumb { get; set; }
        public List<int> Genres { get; set; } = new List<int>();

    }
}
