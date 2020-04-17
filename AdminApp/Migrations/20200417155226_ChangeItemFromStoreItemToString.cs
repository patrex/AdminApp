using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApp.Migrations
{
    public partial class ChangeItemFromStoreItemToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_StoreItems_ItemId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_ItemId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Requests");

            migrationBuilder.AddColumn<string>(
                name: "Item",
                table: "Requests",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Item",
                table: "Requests");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ItemId",
                table: "Requests",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_StoreItems_ItemId",
                table: "Requests",
                column: "ItemId",
                principalTable: "StoreItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
