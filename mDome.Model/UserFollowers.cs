using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class UserFollowers
    {
        public int UserId { get; set; }
        public int FollowedByUserId { get; set; }
    }
}
