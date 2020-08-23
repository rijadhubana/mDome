using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class PostUpsertRequest
    {
        public string PostText { get; set; }
        public int? UserRelatedId { get; set; }
        public int? ReviewRelatedId { get; set; }
        public int? ArtistRelatedId { get; set; }
        public bool? IsGlobal { get; set; }
        public DateTime PostDateTime { get; set; }
        public string PostTitle { get; set; }
        public byte[] PostPhoto { get; set; }
        public byte[] Opphoto { get; set; }
        public string AdminName { get; set; }
    }
}
