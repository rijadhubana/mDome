using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class Post
    {
        public Post()
        {
            UserCommentPost = new HashSet<UserCommentPost>();
            UserLikePost = new HashSet<UserLikePost>();
        }

        public int PostId { get; set; }
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

        public virtual Artist ArtistRelated { get; set; }
        public virtual Review ReviewRelated { get; set; }
        public virtual UserProfile UserRelated { get; set; }
        public virtual ICollection<UserCommentPost> UserCommentPost { get; set; }
        public virtual ICollection<UserLikePost> UserLikePost { get; set; }
    }
}
