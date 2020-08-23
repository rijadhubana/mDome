using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class UserCommentPostUpsertRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        public DateTime CommentDate { get; set; }
    }
}
