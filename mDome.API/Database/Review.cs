using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class Review
    {
        public Review()
        {
            Post = new HashSet<Post>();
        }

        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public string FavouriteSongs { get; set; }
        public string LeastFavouriteSongs { get; set; }
        public int Rating { get; set; }
        public int AlbumId { get; set; }
        public int UserId { get; set; }

        public virtual Album Album { get; set; }
        public virtual UserProfile User { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
