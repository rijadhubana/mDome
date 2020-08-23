using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class AlbumList
    {
        public int AlbumListId { get; set; }
        public string AlbumListName { get; set; }
        public DateTime ListDateCreated { get; set; }
        public int UserId { get; set; }
        public string UniqueKey { get; set; }
        public string AlbumListType { get; set; }
        public string AlbumListDescription { get; set; }
    }
}
