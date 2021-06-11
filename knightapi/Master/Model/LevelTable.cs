using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public class LevelTable
    {
        public int Id { get; set; }
        public int? Level { get; set; }
        public int? Experience { get; set; }
        public int? BaseStats { get; set; }
    }
}
