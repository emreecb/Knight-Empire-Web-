using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int? AttackBonus { get; set; }
        public int? DefenceBonus { get; set; }
        public int? HealthBonus { get; set; }
        public string Photo { get; set; }
        public bool? Active { get; set; }
        public bool? DeleteStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
