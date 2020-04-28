using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApp.Migrations
{
    public partial class AddItemIdFieldToRequestsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Requests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Requests");
        }
    }
}
