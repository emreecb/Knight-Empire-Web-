using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.Migrations
{
    public partial class itemcost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cost",
                table: "Item",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemType",
                table: "Inventory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Inventory",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Wearing",
                table: "Inventory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_PetId",
                table: "Inventory",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Pet_PetId",
                table: "Inventory",
                column: "PetId",
                principalTable: "Pet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Pet_PetId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_PetId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Wearing",
                table: "Inventory");
        }
    }
}
