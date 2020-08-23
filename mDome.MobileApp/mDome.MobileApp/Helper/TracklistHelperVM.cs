using mDome.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.MobileApp.Helper
{
    public class TracklistHelperVM
    {
        public int TracklistId { get; set; }
        public string TracklistName { get; set; }
        public DateTime ListDateCreated { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string NumberOfTracks { get; set; }

    }
}
