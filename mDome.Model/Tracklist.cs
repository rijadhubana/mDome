using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class Tracklist
    {
        public int TracklistId { get; set; }
        public string TracklistName { get; set; }
        public DateTime ListDateCreated { get; set; }
        public int UserId { get; set; }
        public string UniqueKey { get; set; }
        public string TracklistType { get; set; }
    }
}
