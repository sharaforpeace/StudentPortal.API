using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentPortal.API.Migrations
{
    public partial class ss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Gendder_GenderId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gendder",
                table: "Gendder");

            migrationBuilder.RenameTable(
                name: "Gendder",
                newName: "Gender");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gender",
                table: "Gender",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Gender_GenderId",
                table: "Student",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Gender_GenderId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gender",
                table: "Gender");

            migrationBuilder.RenameTable(
                name: "Gender",
                newName: "Gendder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gendder",
                table: "Gendder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Gendder_GenderId",
                table: "Student",
                column: "GenderId",
                principalTable: "Gendder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
