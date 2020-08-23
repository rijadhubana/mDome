using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class AlbumListUpsertRequest
    {
        [Required]
        public string AlbumListName { get; set; }
        public DateTime ListDateCreated { get; set; }
        [Required]
        public int UserId { get; set; }
        public string UniqueKey { get; set; }
        public string AlbumListType { get; set; }
        public string AlbumListDescription { get; set; }
    }
}
