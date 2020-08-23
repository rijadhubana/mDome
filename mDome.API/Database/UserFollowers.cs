using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class UserFollowers
    {
        public int UserId { get; set; }
        public int FollowedByUserId { get; set; }

        public virtual UserProfile FollowedByUser { get; set; }
        public virtual UserProfile User { get; set; }
    }
}
