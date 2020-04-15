using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApp.Migrations
{
    public partial class AddMoreModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequesterEmail = table.Column<string>(nullable: false),
                    IssuerId = table.Column<int>(nullable: false),
                    QuantityIssued = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Issues_Users_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: false),
                    QuantityAdded = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityRequested = table.Column<int>(nullable: false),
                    UserRequestingId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_StoreItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "StoreItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Users_UserRequestingId",
                        column: x => x.UserRequestingId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssuerId",
                table: "Issues",
                column: "IssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ItemId",
                table: "Requests",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserRequestingId",
                table: "Requests",
                column: "UserRequestingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "StoreItems");
        }
    }
}
