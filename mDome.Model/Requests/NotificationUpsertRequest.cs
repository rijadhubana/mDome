using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class NotificationUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string NotifText { get; set; }
        public DateTime? NotifDateTime { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
