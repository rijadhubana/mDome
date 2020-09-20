using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model
{
    public class LoginLogTable
    {
        public int LoginLogTableId { get; set; }
        public DateTime DateOfLogin { get; set; }
        public int UserId { get; set; }
        public string NameOfUser { get; set; }
    }
}
