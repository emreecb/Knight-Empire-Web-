using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public class Haber
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Explanation { get; set; }
        public DateTimeOffset? AddTime { get; set; }
        public DateTimeOffset? UpdateTime { get; set; }

        public bool? DeleteStatus { get; set; }
        public bool? Active { get; set; }
    }
}
