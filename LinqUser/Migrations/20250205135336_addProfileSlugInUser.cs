using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinqUser.Migrations
{
    /// <inheritdoc />
    public partial class addProfileSlugInUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileSlug",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileSlug",
                table: "AspNetUsers");
        }
    }
}
