using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class AlbumListAlbumUpsertRequest
    {
        [Required]
        public int AlbumListId { get; set; }
        [Required]
        public int AlbumId { get; set; }
    }
}
