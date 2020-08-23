using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class ArtistGenreSearchRequest
    {
        public int? GenreId { get; set; }
        public int? ArtistId { get; set; }
    }
}
