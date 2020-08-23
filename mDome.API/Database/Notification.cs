using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public string NotifText { get; set; }
        public DateTime? NotifDateTime { get; set; }
        public int UserId { get; set; }

        public virtual UserProfile User { get; set; }
    }
}
