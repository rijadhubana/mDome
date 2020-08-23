using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class UserFollowersSearchRequest
    {
        public int? UserId { get; set; }
        public int? FollowedByUserId { get; set; }
    }
}
