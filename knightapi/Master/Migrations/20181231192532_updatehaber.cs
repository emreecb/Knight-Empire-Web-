using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.Migrations
{
    public partial class updatehaber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Haber",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Explanation = table.Column<string>(nullable: true),
                    AddTime = table.Column<DateTimeOffset>(nullable: true),
                    UpdateTime = table.Column<DateTimeOffset>(nullable: true),
                    DeleteStatus = table.Column<bool>(nullable: true),
                    Active = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haber", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Haber");
        }
    }
}
