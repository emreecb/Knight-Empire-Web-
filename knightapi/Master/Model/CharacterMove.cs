using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public class CharacterMove
    {
        public int Id { get; set; }
        public int? CharacterDetailsId { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public int? Type { get; set; }
        public bool? DeleteStatus { get; set; }
    }
}
