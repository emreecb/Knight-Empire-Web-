﻿// <auto-generated />
using System;
using Master.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Master.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20181129221449_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Master.Model.AcilisBildirim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<bool?>("DeleteStatus");

                    b.Property<string>("Photo");

                    b.Property<string>("SubTitle");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("AcilisBildirim");
                });

            modelBuilder.Entity("Master.Model.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DogumTarihi");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<long?>("FacebookId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PictureUrl");

                    b.Property<string>("RolesId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Master.Model.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active");

                    b.Property<string>("AreaName");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<bool?>("DeleteStatus");

                    b.Property<int?>("LevelCap");

                    b.Property<string>("Photo");

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("Master.Model.AreaMob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaId");

                    b.Property<int?>("MobId");

                    b.HasKey("Id");

                    b.ToTable("AreaMob");
                });

            modelBuilder.Entity("Master.Model.CharacterDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharacterLevel");

                    b.Property<int?>("Experience");

                    b.Property<int?>("Health");

                    b.Property<string>("IdentityId");

                    b.Property<int?>("Mana");

                    b.Property<bool?>("Nation");

                    b.Property<int?>("NationalPoint");

                    b.Property<string>("Nickname");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("CharacterDetails");
                });

            modelBuilder.Entity("Master.Model.Galeri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<bool?>("DeleteStatus");

                    b.Property<string>("Explanation");

                    b.Property<string>("Photo");

                    b.Property<string>("SubTitle");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("Galeri");
                });

            modelBuilder.Entity("Master.Model.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active");

                    b.Property<int?>("CharacterDetailsID");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<bool?>("DeleteStatus");

                    b.Property<int?>("ItemId");

                    b.Property<int?>("ItemLevel");

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("Master.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active");

                    b.Property<decimal?>("Attack");

                    b.Property<int?>("BonusMultiplier");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<decimal?>("Defans");

                    b.Property<bool?>("DeleteStatus");

                    b.Property<int?>("DropGroup");

                    b.Property<decimal?>("DropRate");

                    b.Property<decimal?>("FlameBonus");

                    b.Property<decimal?>("GlacierBonus");

                    b.Property<decimal?>("Health");

                    b.Property<string>("ItemAbout");

                    b.Property<string>("ItemName");

                    b.Property<int>("ItemType");

                    b.Property<decimal?>("LightningBonus");

                    b.Property<string>("Photo");

                    b.Property<decimal?>("PoisonBonus");

                    b.Property<int?>("StatMultiplier");

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Master.Model.ItemLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ItemType");

                    b.Property<int?>("Level");

                    b.Property<decimal?>("Multiplier");

                    b.HasKey("Id");

                    b.ToTable("ItemLevel");
                });

            modelBuilder.Entity("Master.Model.LevelTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BaseStats");

                    b.Property<int?>("Experience");

                    b.Property<int?>("Level");

                    b.HasKey("Id");

                    b.ToTable("LevelTable");
                });

            modelBuilder.Entity("Master.Model.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("AddTime");

                    b.Property<bool?>("DeleteStatus");

                    b.Property<string>("ItemAd");

                    b.Property<int?>("ItemType");

                    b.Property<string>("Photo");

                    b.Property<decimal?>("Price");

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("Market");
                });

            modelBuilder.Entity("Master.Model.Mob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active");

                    b.Property<int?>("Attack");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<int?>("Defense");

                    b.Property<bool?>("DeleteStatus");

                    b.Property<int?>("Drop");

                    b.Property<int?>("DropGroup");

                    b.Property<int?>("Health");

                    b.Property<int?>("ManaValue");

                    b.Property<int?>("MaxCoin");

                    b.Property<int?>("MaxExp");

                    b.Property<int?>("MinCoin");

                    b.Property<int?>("MinExp");

                    b.Property<int?>("MinLevel");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("Mob");
                });

            modelBuilder.Entity("Master.Model.Money", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharacterDetailsId");

                    b.Property<int?>("Coin");

                    b.Property<int?>("KnightPoint");

                    b.HasKey("Id");

                    b.ToTable("Money");
                });

            modelBuilder.Entity("Master.Model.NetPol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<bool?>("DeleteStatus");

                    b.Property<string>("Explanation");

                    b.Property<string>("Name");

                    b.Property<int?>("Rank");

                    b.Property<string>("SubTitle");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("NetPol");
                });

            modelBuilder.Entity("Master.Model.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active");

                    b.Property<decimal?>("AttackBonus");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<decimal?>("DefenseBonus");

                    b.Property<bool?>("DeleteStatus");

                    b.Property<decimal?>("HealthBonus");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.Property<decimal?>("Price");

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("Master.Model.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<bool?>("DeleteStatus");

                    b.Property<string>("Photo");

                    b.Property<int?>("Rank");

                    b.Property<string>("SubTitle");

                    b.Property<string>("Title");

                    b.Property<DateTime?>("UpdateTime");

                    b.HasKey("Id");

                    b.ToTable("Slider");
                });

            modelBuilder.Entity("Master.Model.SosyalMedya", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active");

                    b.Property<DateTime?>("CreateTime");

                    b.Property<bool?>("DeleteStatus");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdateTime");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("SosyalMedya");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Master.Model.CharacterDetails", b =>
                {
                    b.HasOne("Master.Model.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Master.Model.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Master.Model.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Master.Model.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Master.Model.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
