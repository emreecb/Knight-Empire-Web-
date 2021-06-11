using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public class Gift
    {
        public int Id { get; set; }
        public string Explanation { get; set; }
        public int? Level { get; set; }
        public int? Mana { get; set; }
        public int? Coin { get; set; }
        public int? KPoint { get; set; }
    }
}
