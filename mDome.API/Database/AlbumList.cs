using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class AlbumList
    {
        public AlbumList()
        {
            AlbumListAlbum = new HashSet<AlbumListAlbum>();
        }

        public int AlbumListId { get; set; }
        public string AlbumListName { get; set; }
        public DateTime ListDateCreated { get; set; }
        public int UserId { get; set; }
        public string UniqueKey { get; set; }
        public string AlbumListType { get; set; }
        public string AlbumListDescription { get; set; }

        public virtual UserProfile User { get; set; }
        public virtual ICollection<AlbumListAlbum> AlbumListAlbum { get; set; }
    }
}
