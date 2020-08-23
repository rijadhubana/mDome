using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class RequestUpsertRequest
    {

        [Required(AllowEmptyStrings =false)]
        public string RequestText { get; set; }
        [Required]
        public int UserId { get; set; }
        public string NameOfUser { get; set; }
        public DateTime RequestDate { get; set; }

    }
}
