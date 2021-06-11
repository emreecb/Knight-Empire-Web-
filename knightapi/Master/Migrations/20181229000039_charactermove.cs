using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.Migrations
{
    public partial class charactermove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "CharacterMove",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Type",
                table: "CharacterMove",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
