using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class UserLikePost
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public bool Liked { get; set; }

        public virtual Post Post { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
