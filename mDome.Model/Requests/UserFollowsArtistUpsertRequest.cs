using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class UserFollowsArtistUpsertRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ArtistId { get; set; }
    }
}
