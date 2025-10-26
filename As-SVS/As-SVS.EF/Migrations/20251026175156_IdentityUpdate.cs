using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsSVS.EF.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "permissions",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "Custom",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Custom");

            migrationBuilder.AddColumn<int>(
                name: "permissions",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
