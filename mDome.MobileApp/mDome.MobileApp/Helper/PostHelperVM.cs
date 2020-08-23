using mDome.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.MobileApp.Helper
{
    public class PostHelperVM
    {
        public int PostId { get; set; }
        public string PostText { get; set; }
        public DateTime PostDateTime { get; set; }
        public string PostTitle { get; set; }
        public byte[] PostPhoto { get; set; }
        public byte[] OPPhoto { get; set; }
        public string AdminName { get; set; }
    }
}
