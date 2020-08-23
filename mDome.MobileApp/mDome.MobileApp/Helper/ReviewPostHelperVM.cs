using mDome.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.MobileApp.Helper
{
    class ReviewPostHelperVM
    {
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public string FavouriteSongs { get; set; }
        public string LeastFavouriteSongs { get; set; }
        public string Username { get; set; }
        public string Rating { get; set; }
        public int PostId { get; set; }
        public byte[] PostPhoto { get; set; }
        public DateTime PostDateTime { get; set; }


    }
}
