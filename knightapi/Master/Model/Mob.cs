using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public class Mob
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? MinLevel { get; set; }
        public int? Health { get; set; }
        public int? Defense { get; set; }
        public int? Attack { get; set; }
        public int MaxExp { get; set; }
        public int MinExp { get; set; }
        public int MaxCoin { get; set; }
        public int MinCoin { get; set; }
        public int? Drop { get; set; }
        public int? DropGroup { get; set; }
        public string Photo { get; set; }
        public int? ManaValue { get; set; }
        public bool? Active { get; set; }
        public bool? DeleteStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

    }
}
