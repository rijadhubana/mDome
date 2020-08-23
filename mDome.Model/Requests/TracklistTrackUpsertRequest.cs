using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class TracklistTrackUpsertRequest
    {
        [Required]
        public int TracklistId { get; set; }
        [Required]
        public int TrackId { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
