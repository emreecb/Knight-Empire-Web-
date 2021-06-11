using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.Migrations
{
    public partial class updatestat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_ItemLevel_ItemlevelId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ItemlevelId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "DefenseBonus",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Defans",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemlevelId",
                table: "Inventory");

            migrationBuilder.AlterColumn<int>(
                name: "HealthBonus",
                table: "Pet",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AttackBonus",
                table: "Pet",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefenceBonus",
                table: "Pet",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PoisonBonus",
                table: "Item",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LightningBonus",
                table: "Item",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Health",
                table: "Item",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GlacierBonus",
                table: "Item",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FlameBonus",
                table: "Item",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DropRate",
                table: "Item",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Attack",
                table: "Item",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Defence",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Attack",
                table: "CharacterDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Defence",
                table: "CharacterDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlameBonus",
                table: "CharacterDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GlacierBonus",
                table: "CharacterDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LightningBonus",
                table: "CharacterDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MobLost",
                table: "CharacterDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MobWon",
                table: "CharacterDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PoisonBonus",
                table: "CharacterDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PvpLost",
                table: "CharacterDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PvpWon",
                table: "CharacterDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefenceBonus",
                table: "Pet");

            migrationBuilder.DropColumn(
                name: "Defence",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Attack",
                table: "CharacterDetails");

            migrationBuilder.DropColumn(
                name: "Defence",
                table: "CharacterDetails");

            migrationBuilder.DropColumn(
                name: "FlameBonus",
                table: "CharacterDetails");

            migrationBuilder.DropColumn(
                name: "GlacierBonus",
                table: "CharacterDetails");

            migrationBuilder.DropColumn(
                name: "LightningBonus",
                table: "CharacterDetails");

            migrationBuilder.DropColumn(
                name: "MobLost",
                table: "CharacterDetails");

            migrationBuilder.DropColumn(
                name: "MobWon",
                table: "CharacterDetails");

            migrationBuilder.DropColumn(
                name: "PoisonBonus",
                table: "CharacterDetails");

            migrationBuilder.DropColumn(
                name: "PvpLost",
                table: "CharacterDetails");

            migrationBuilder.DropColumn(
                name: "PvpWon",
                table: "CharacterDetails");

            migrationBuilder.AlterColumn<decimal>(
                name: "HealthBonus",
                table: "Pet",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AttackBonus",
                table: "Pet",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DefenseBonus",
                table: "Pet",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PoisonBonus",
                table: "Item",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "LightningBonus",
                table: "Item",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Health",
                table: "Item",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "GlacierBonus",
                table: "Item",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "FlameBonus",
                table: "Item",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DropRate",
                table: "Item",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Attack",
                table: "Item",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Defans",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemlevelId",
                table: "Inventory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ItemlevelId",
                table: "Inventory",
                column: "ItemlevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_ItemLevel_ItemlevelId",
                table: "Inventory",
                column: "ItemlevelId",
                principalTable: "ItemLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
