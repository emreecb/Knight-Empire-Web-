using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public class Inventory
    {
        public int Id { get; set; }
        public int? CharacterDetailsID { get; set; }
        public int? ItemType { get; set; }
        public int? PetId { get; set; }
        public int? ItemId { get; set; }
        public int? ItemLevel { get; set; }
        public bool Wearing { get; set; }
        public bool? Active { get; set; }
        public bool? DeleteStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }

        public Item Item { get; set; }
        public Pet Pet { get; set; }
    }
}
