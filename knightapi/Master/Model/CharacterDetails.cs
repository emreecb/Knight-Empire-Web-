using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public class CharacterDetails
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public int? CharacterLevel { get; set; }
        public int? Experience { get; set; }
        public bool? Nation { get; set; }
        public int? NationalPoint { get; set; }
        public int? Health { get; set; }
        public int? Mana { get; set; }
        public int? PvpWon { get; set; }
        public int? PvpLost { get; set; }
        public int? MobWon { get; set; }
        public int? MobLost { get; set; }

        public int? Defence { get; set; }
        public int? Attack { get; set; }
        public int? PoisonBonus { get; set; }
        public int? FlameBonus { get; set; }

        public int? GlacierBonus { get; set; }

        public int? LightningBonus { get; set; }



        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }
    }
}
