using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class UserCommentPost
    {
        public int UserCommentPostId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }

        public virtual Post Post { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
