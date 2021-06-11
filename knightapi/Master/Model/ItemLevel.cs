using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public class ItemLevel
    {
        public int Id { get; set; }
        public int? ItemType { get; set; }
        public int? Level { get; set; }
        public decimal? Multiplier { get; set; }
    }
}
