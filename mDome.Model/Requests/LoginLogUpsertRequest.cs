using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.Requests
{
    public class LoginLogUpsertRequest
    {
        public DateTime DateOfLogin { get; set; }
        public int UserId { get; set; }
        public string NameOfUser { get; set; }
    }
}
