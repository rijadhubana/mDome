using System;
using System.Collections.Generic;

namespace mDome.API.Database
{
    public partial class LoginLogTable
    {
        public int LoginLogTableId { get; set; }
        public DateTime DateOfLogin { get; set; }
        public int UserId { get; set; }
        public string NameOfUser { get; set; }

        public virtual UserProfile User { get; set; }
    }
}
