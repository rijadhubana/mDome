using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace mDome.Model.Requests
{
    public class GenreUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
    }
}
