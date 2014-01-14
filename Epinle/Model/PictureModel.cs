using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epinle.Model
{
    public class PictureModel
    {
        public string file_id { get; set; }
        public string image_url { get; set; }
        public string image_id { get; set; }
        public string rand_store_id { get; set; }
        public string set_cover { get; set; }
        public string sort_order { get; set; }
        public string store_id { get; set; }
        public string thumbnail { get; set; }

        public string title { get; set; }

        public string default_image { get; set; }
        public string has_images { get; set; }
    }
}
