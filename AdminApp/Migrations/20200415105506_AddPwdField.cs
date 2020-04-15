using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApp.Migrations
{
    public partial class AddPwdField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_IssuerId",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_UserRequestingId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Requests_UserRequestingId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Issues_IssuerId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRequestingId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IssuerId",
                table: "Issues");

            migrationBuilder.AddColumn<string>(
                name: "eMail",
                table: "Users",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pswd",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserRequestingeMail",
                table: "Requests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuereMail",
                table: "Issues",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "ConfirmedEvents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "eMail");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserRequestingeMail",
                table: "Requests",
                column: "UserRequestingeMail");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssuereMail",
                table: "Issues",
                column: "IssuereMail");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_IssuereMail",
                table: "Issues",
                column: "IssuereMail",
                principalTable: "Users",
                principalColumn: "eMail",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_UserRequestingeMail",
                table: "Requests",
                column: "UserRequestingeMail",
                principalTable: "Users",
                principalColumn: "eMail",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Users_IssuereMail",
                table: "Issues");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Users_UserRequestingeMail",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Requests_UserRequestingeMail",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Issues_IssuereMail",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "eMail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Pswd",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRequestingeMail",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IssuereMail",
                table: "Issues");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UserRequestingId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IssuerId",
                table: "Issues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "ConfirmedEvents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserRequestingId",
                table: "Requests",
                column: "UserRequestingId");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssuerId",
                table: "Issues",
                column: "IssuerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Users_IssuerId",
                table: "Issues",
                column: "IssuerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Users_UserRequestingId",
                table: "Requests",
                column: "UserRequestingId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
