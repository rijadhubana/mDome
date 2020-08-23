using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string NotifText { get; set; }
        public DateTime? NotifDateTime { get; set; }
        public int UserId { get; set; }
    }
}
