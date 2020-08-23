using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class UserCommentPost
    {
        public int UserCommentPostId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
