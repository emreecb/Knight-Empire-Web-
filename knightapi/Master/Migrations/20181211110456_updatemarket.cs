using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.Migrations
{
    public partial class updatemarket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Etken",
                table: "Market",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Etken",
                table: "Market");
        }
    }
}
