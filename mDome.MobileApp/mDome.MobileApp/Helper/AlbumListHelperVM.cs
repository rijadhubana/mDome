using mDome.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.MobileApp.Helper
{
    public class AlbumListHelperVM
    {
        public int AlbumListId { get; set; }
        public string AlbumListName { get; set; }
        public DateTime ListDateCreated { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string NumberOfAlbums { get; set; }

    }
}
