using System;
using System.Collections.Generic;
using System.Text;

namespace THTR.Common.DTOs.Entities
{
    public class Star
    {
        public Guid id { get; set; }
        public string? first_name { get; set;  }
        public string? last_name { get; set; }
        public string? handle { get; set; }
    }
}
