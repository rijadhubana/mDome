using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class Request
    {
        public int RequestId { get; set; }
        public string RequestText { get; set; }
        public int UserId { get; set; }
        public string NameOfUser { get; set; }
        public DateTime RequestDate { get; set; }

        public virtual UserProfile User { get; set; }
    }
}
