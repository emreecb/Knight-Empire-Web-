using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public class Money
    {
        public int Id { get; set; }
        public int? CharacterDetailsId { get; set; }
        public int? Coin { get; set; }
        public int? KnightPoint { get; set; }

    }
}
