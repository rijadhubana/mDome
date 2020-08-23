using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class UserTrackVoteUpsertRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TrackId { get; set; }
        [Required]

        public bool Liked { get; set; }
    }
}
