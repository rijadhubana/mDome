using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.MobileApp.Helper
{
    public class ArtistHelperVM
    {
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string ArtistMembers { get; set; }
        public string ArtistGenresInString { get; set; }
        public byte[] ArtistPhoto { get; set; }
        public int SumTrackViews { get; set; }
    }
}
