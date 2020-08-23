using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class ReviewSearchRequest
    {
        public int? AlbumId { get; set; }
        public int? RatingFrom { get; set; }
        public int? RatingTo { get; set; }
        public int? UserId { get; set; }

    }
}
