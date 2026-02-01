using System;
using System.Collections.Generic;
using System.Text;

namespace THTR.Common.DTOs.Entities
{
    public class Character
    {        
        public Guid id { get; set; }        
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? backstory { get; set; }
        public int? age { get; set; }
        public string? location { get; set; }
        public string? identity { get; set; }
        public string? education { get; set; }
        public string? occupation { get; set; }
        public string? family { get; set; }
        public string? personality { get; set; }
        public string? worldview { get; set; }
    }
}
