using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class TracklistTrackSearchRequest
    {
        public int? TracklistId { get; set; }
        public int? TrackId { get; set; }
        public DateTime? DateAddedFrom { get; set; }
        public DateTime? DateAddedTo { get; set; }

    }
}
