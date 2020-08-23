using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class TracklistUpsertRequest
    {
        [Required]
        public string TracklistName { get; set; }
        public DateTime ListDateCreated { get; set; }
        [Required]
        public int UserId { get; set; }
        public string UniqueKey { get; set; }
        [Required]
        public string TracklistType { get; set; }
    }
}
