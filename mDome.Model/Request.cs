using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class Request
    {
        public int RequestId { get; set; }
        public string RequestText { get; set; }
        public int UserId { get; set; }
        public string NameOfUser { get; set; }
        public DateTime RequestDate { get; set; }

    }
}
