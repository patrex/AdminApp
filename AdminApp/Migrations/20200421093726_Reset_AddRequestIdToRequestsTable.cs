using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApp.Migrations
{
    public partial class Reset_AddRequestIdToRequestsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfirmedEvents",
                columns: table => new
                {
                    EventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfirmedEvents", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Venue = table.Column<string>(nullable: false),
                    HostId = table.Column<string>(nullable: false),
                    EventDateTime = table.Column<DateTime>(nullable: false),
                    Approved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequesterEmail = table.Column<string>(nullable: false),
                    Issuer = table.Column<string>(nullable: false),
                    QuantityIssued = table.Column<int>(nullable: false),
                    IssuedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityRequested = table.Column<int>(nullable: false),
                    Purpose = table.Column<string>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    UserRequesting = table.Column<string>(nullable: false),
                    Item = table.Column<string>(nullable: false),
                    RequesterEmail = table.Column<string>(nullable: false),
                    IsServed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                });

            migrationBuilder.CreateTable(
                name: "StoreItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: false),
                    QuantityAdded = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    QtyLeft = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    eMail = table.Column<string>(nullable: false),
                    Pswd = table.Column<string>(nullable: false),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    IsElevatedUser = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.eMail);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfirmedEvents");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Issues");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "StoreItems");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
