using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinqUser.Migrations
{
    /// <inheritdoc />
    public partial class AddChangeUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "profileUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_profileUsers_UserId",
                table: "profileUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_profileUsers_AspNetUsers_UserId",
                table: "profileUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_profileUsers_AspNetUsers_UserId",
                table: "profileUsers");

            migrationBuilder.DropIndex(
                name: "IX_profileUsers_UserId",
                table: "profileUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "profileUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
