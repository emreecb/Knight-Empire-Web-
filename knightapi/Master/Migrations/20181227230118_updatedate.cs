using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.Migrations
{
    public partial class updatedate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MinExp",
                table: "Mob",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MinCoin",
                table: "Mob",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxExp",
                table: "Mob",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaxCoin",
                table: "Mob",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "StartTime",
                table: "CharacterMove",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MinExp",
                table: "Mob",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MinCoin",
                table: "Mob",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MaxExp",
                table: "Mob",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MaxCoin",
                table: "Mob",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "CharacterMove",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true);
        }
    }
}
