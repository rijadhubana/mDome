using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class ArtistGenre
    {
        public int GenreId { get; set; }
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
