using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class UserAlbumVoteUpsertRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int AlbumId { get; set; }
        [Required]
        public bool Liked { get; set; }
    }
}
