using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public class Area
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public int? LevelCap { get; set; }
        public bool? Active { get; set; }
        public string Photo { get; set; }
        public bool? DeleteStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
