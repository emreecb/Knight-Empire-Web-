using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcilisBildirim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcilisBildirim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaName = table.Column<string>(nullable: true),
                    LevelCap = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaMob",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<int>(nullable: true),
                    MobId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaMob", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FacebookId = table.Column<long>(nullable: true),
                    PictureUrl = table.Column<string>(nullable: true),
                    RolesId = table.Column<string>(nullable: true),
                    DogumTarihi = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Galeri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    Explanation = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galeri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterDetailsID = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: true),
                    ItemLevel = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemName = table.Column<string>(nullable: true),
                    ItemType = table.Column<int>(nullable: false),
                    ItemAbout = table.Column<string>(nullable: true),
                    Attack = table.Column<decimal>(nullable: true),
                    Defans = table.Column<decimal>(nullable: true),
                    Health = table.Column<decimal>(nullable: true),
                    DropRate = table.Column<decimal>(nullable: true),
                    FlameBonus = table.Column<decimal>(nullable: true),
                    GlacierBonus = table.Column<decimal>(nullable: true),
                    LightningBonus = table.Column<decimal>(nullable: true),
                    PoisonBonus = table.Column<decimal>(nullable: true),
                    DropGroup = table.Column<int>(nullable: true),
                    StatMultiplier = table.Column<int>(nullable: true),
                    BonusMultiplier = table.Column<int>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemLevel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemType = table.Column<int>(nullable: true),
                    Level = table.Column<int>(nullable: true),
                    Multiplier = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LevelTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Level = table.Column<int>(nullable: true),
                    Experience = table.Column<int>(nullable: true),
                    BaseStats = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemAd = table.Column<string>(nullable: true),
                    ItemType = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: true),
                    AddTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mob",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MinLevel = table.Column<int>(nullable: true),
                    Health = table.Column<int>(nullable: true),
                    Defense = table.Column<int>(nullable: true),
                    Attack = table.Column<int>(nullable: true),
                    MaxExp = table.Column<int>(nullable: true),
                    MinExp = table.Column<int>(nullable: true),
                    MaxCoin = table.Column<int>(nullable: true),
                    MinCoin = table.Column<int>(nullable: true),
                    Drop = table.Column<int>(nullable: true),
                    DropGroup = table.Column<int>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    ManaValue = table.Column<int>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mob", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CharacterDetailsId = table.Column<int>(nullable: true),
                    Coin = table.Column<int>(nullable: true),
                    KnightPoint = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Money", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NetPol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    Explanation = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetPol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    AttackBonus = table.Column<decimal>(nullable: true),
                    DefenseBonus = table.Column<decimal>(nullable: true),
                    HealthBonus = table.Column<decimal>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Rank = table.Column<int>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SosyalMedya",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: true),
                    Active = table.Column<bool>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SosyalMedya", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nickname = table.Column<string>(nullable: true),
                    CharacterLevel = table.Column<int>(nullable: true),
                    Experience = table.Column<int>(nullable: true),
                    Nation = table.Column<bool>(nullable: true),
                    NationalPoint = table.Column<int>(nullable: true),
                    Health = table.Column<int>(nullable: true),
                    Mana = table.Column<int>(nullable: true),
                    IdentityId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CharacterDetails_AspNetUsers_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterDetails_IdentityId",
                table: "CharacterDetails",
                column: "IdentityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcilisBildirim");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "AreaMob");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CharacterDetails");

            migrationBuilder.DropTable(
                name: "Galeri");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "ItemLevel");

            migrationBuilder.DropTable(
                name: "LevelTable");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropTable(
                name: "Mob");

            migrationBuilder.DropTable(
                name: "Money");

            migrationBuilder.DropTable(
                name: "NetPol");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "SosyalMedya");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
