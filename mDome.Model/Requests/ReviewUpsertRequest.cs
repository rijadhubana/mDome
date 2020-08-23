using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class ReviewUpsertRequest
    {
        [Required]
        public string ReviewText { get; set; }
        public string FavouriteSongs { get; set; }
        public string LeastFavouriteSongs { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required]
        public int AlbumId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
