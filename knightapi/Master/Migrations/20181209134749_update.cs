using Microsoft.EntityFrameworkCore.Migrations;

namespace Master.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemlevelId",
                table: "Inventory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ItemId",
                table: "Inventory",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ItemlevelId",
                table: "Inventory",
                column: "ItemlevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Item_ItemId",
                table: "Inventory",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_ItemLevel_ItemlevelId",
                table: "Inventory",
                column: "ItemlevelId",
                principalTable: "ItemLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Item_ItemId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_ItemLevel_ItemlevelId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ItemId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ItemlevelId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ItemlevelId",
                table: "Inventory");
        }
    }
}
