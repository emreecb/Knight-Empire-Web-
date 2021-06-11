using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int ItemType { get; set; }
        public string ItemAbout { get; set; }
        public int? Attack { get; set; }
        public int? Defence { get; set; }
        public int? Health { get; set; }
        public int? DropRate { get; set; }
        public int? FlameBonus { get; set; }
        public int? GlacierBonus { get; set; }
        public int? LightningBonus { get; set; }
        public int? PoisonBonus { get; set; }
        public int? DropGroup { get; set; }
        public int? StatMultiplier { get; set; }
        public int? BonusMultiplier { get; set; }
        public int? Cost { get; set; }
        public string Photo { get; set; }
        public bool? Active { get; set; }
        public bool? DeleteStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
