using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsSVS.EF.Migrations
{
    /// <inheritdoc />
    public partial class FitWithIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_People",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_People",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_People",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_People",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_person_id",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_person_id",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Messages_person_id",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Admins_person_id",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "UQ_Admins_Username",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "person_id",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "person_id",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "person_id",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "person_id",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "username",
                table: "Admins");

            migrationBuilder.AddColumn<string>(
                name: "applicationUser_id",
                table: "Teachers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "applicationUser_id",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "applicationUser_id",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "applicationUser_id",
                table: "Admins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_applicationUser_id",
                table: "Teachers",
                column: "applicationUser_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_applicationUser_id",
                table: "Students",
                column: "applicationUser_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_applicationUser_id",
                table: "Messages",
                column: "applicationUser_id");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_applicationUser_id",
                table: "Admins",
                column: "applicationUser_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_People",
                table: "Admins",
                column: "applicationUser_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_People",
                table: "Messages",
                column: "applicationUser_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_People",
                table: "Students",
                column: "applicationUser_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_People",
                table: "Teachers",
                column: "applicationUser_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_People",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_People",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_People",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_People",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_applicationUser_id",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_applicationUser_id",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Messages_applicationUser_id",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Admins_applicationUser_id",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "applicationUser_id",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "applicationUser_id",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "applicationUser_id",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "applicationUser_id",
                table: "Admins");

            migrationBuilder.AddColumn<int>(
                name: "person_id",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "person_id",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "person_id",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "person_id",
                table: "Admins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "Admins",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: false),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gender = table.Column<bool>(type: "bit", nullable: false),
                    image_url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    middle_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_person_id",
                table: "Teachers",
                column: "person_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_person_id",
                table: "Students",
                column: "person_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_person_id",
                table: "Messages",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_person_id",
                table: "Admins",
                column: "person_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Admins_Username",
                table: "Admins",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_Pesron_Email",
                table: "People",
                column: "email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_People",
                table: "Admins",
                column: "person_id",
                principalTable: "People",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_People",
                table: "Messages",
                column: "person_id",
                principalTable: "People",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_People",
                table: "Students",
                column: "person_id",
                principalTable: "People",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_People",
                table: "Teachers",
                column: "person_id",
                principalTable: "People",
                principalColumn: "id");
        }
    }
}
