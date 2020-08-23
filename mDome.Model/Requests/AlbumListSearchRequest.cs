using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class AlbumListSearchRequest
    {
        public string AlbumListName { get; set; }
        public int? UserId { get; set; }
        public string UniqueKey { get; set; }
        public string AlbumListType { get; set; }
    }
}
