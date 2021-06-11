using System;
using System.Collections.Generic;

namespace Master.Model
{
    public partial class Galeri
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Explanation { get; set; }
        public string Photo { get; set; }
        public bool? DeleteStatus { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

    }
}
