using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public string FavouriteSongs { get; set; }
        public string LeastFavouriteSongs { get; set; }
        public int Rating { get; set; }
        public int AlbumId { get; set; }
        public int UserId { get; set; }
    }
}
