using System;
using System.Collections.Generic;
using System.Linq;

namespace Master.Model
{
    public partial class AreaMob
    {
        public int Id { get; set; }
        public int? AreaId { get; set; }
        public int? MobId { get; set; }
    }
}
