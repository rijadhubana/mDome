using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class UserLikePostUpsertRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public bool Liked { get; set; }
    }
}
