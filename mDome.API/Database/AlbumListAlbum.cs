using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class AlbumListAlbum
    {
        public int AlbumListId { get; set; }
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
        public virtual AlbumList AlbumList { get; set; }
    }
}
