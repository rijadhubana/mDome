using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class Genre
    {
        public Genre()
        {
            ArtistGenre = new HashSet<ArtistGenre>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }

        public virtual ICollection<ArtistGenre> ArtistGenre { get; set; }
    }
}
