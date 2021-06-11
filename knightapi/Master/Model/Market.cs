using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public class Market
    {
        public int Id { get; set; }
        public string ItemAd { get; set; }
        public int? ItemType { get; set; }
        public decimal? Price { get; set; }
        public int? Etken { get; set; }
        public string Photo { get; set; }
        public bool? Active { get; set; }
        public bool? DeleteStatus { get; set; }
        public DateTime? AddTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
