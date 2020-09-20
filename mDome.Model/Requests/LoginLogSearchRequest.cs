using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class LoginLogSearchRequest
    {
        public DateTime? DateOfLogin { get; set; }
        public int? UserId { get; set; }
    }
}
