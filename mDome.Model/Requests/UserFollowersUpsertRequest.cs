using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class UserFollowersUpsertRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int FollowedByUserId { get; set; }
    }
}
