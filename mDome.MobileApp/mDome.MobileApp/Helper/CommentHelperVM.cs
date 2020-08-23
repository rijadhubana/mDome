using mDome.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.MobileApp.Helper
{
    public class CommentHelperVM
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string CommenterName { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public byte[] CommenterPhoto { get; set; }
    }
}
