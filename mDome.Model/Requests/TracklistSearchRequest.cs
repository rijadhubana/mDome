using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class TracklistSearchRequest
    {
        public string TracklistName { get; set; }
        public int? UserId { get; set; }
        public string UniqueKey { get; set; }
        public string TracklistType { get; set; }
    }
}
