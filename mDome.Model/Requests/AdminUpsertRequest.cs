using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class AdminUpsertRequest
    {
        [Required]
        public string AdminName { get; set; }
        public string PasswordClear { get; set; }
        public string PasswordClearConfirm { get; set; }

    }
}
