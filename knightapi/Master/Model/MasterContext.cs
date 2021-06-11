using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Master.Model
{
    public partial class MasterContext : IdentityDbContext<AppUser>
    {

        public MasterContext(DbContextOptions<MasterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcilisBildirim> AcilisBildirim { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<AreaMob> AreaMob { get; set; }
        public virtual DbSet<CharacterDetails> CharacterDetails { get; set; }
        public virtual DbSet<Galeri> Galeri { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemLevel> ItemLevel { get; set; }
        public virtual DbSet<LevelTable> LevelTable { get; set; }
        public virtual DbSet<Market> Market { get; set; }
        public virtual DbSet<Mob> Mob { get; set; }
        public virtual DbSet<Money> Money { get; set; }
        public virtual DbSet<NetPol> NetPol { get; set; }
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<Slider> Slider { get; set; }
        public virtual DbSet<SosyalMedya> SosyalMedya { get; set; }
        public virtual DbSet<CharacterMove> CharacterMove { get; set; }
        public virtual DbSet<Rutbe> Rutbe { get; set; }
        public virtual DbSet<Haber> Haber { get; set; }
        public virtual DbSet<Gift> Gift { get; set; }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
