using System;
using System.Collections.Generic;
using System.Text;

namespace mDome.Model.YoutubeModels
{
    public class Item
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public Id id { get; set; }
        public Snippet snippet { get; set; }

    }
}
