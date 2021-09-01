using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp1.Migrations
{
    public partial class LinkStudentWithRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoomId",
                table: "Students",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_RenamedRoom_RoomId",
                table: "Students",
                column: "RoomId",
                principalTable: "RenamedRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_RenamedRoom_RoomId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_RoomId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Students");
        }
    }
}
