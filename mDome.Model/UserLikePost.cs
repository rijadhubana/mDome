using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class UserLikePost
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public bool Liked { get; set; }
    }
}
