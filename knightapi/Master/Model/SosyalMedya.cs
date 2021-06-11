using System;
using System.Collections.Generic;

namespace Master.Model
{
    public partial class SosyalMedya
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool? DeleteStatus { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
