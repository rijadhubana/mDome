using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class UserCommentPostSearchRequest
    {
        public int? UserId { get; set; }
        public int? PostId { get; set; }
    }
}
