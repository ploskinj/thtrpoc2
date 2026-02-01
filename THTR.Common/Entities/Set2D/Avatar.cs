using System;
using System.Collections.Generic;
using System.Text;

namespace THTR.Common.Entities.Set2D
{
    public class Avatar
    {
        public Guid id { get; set; }
        public int body_id { get; set; }
        public int skin_tone_id { get; set; }
        public int hair_style_id {  get; set; }
        public int hair_color_id { get; set; }
    }
}
