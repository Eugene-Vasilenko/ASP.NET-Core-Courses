using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp1.Migrations
{
    public partial class changeStudentRoomLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfile_Students_StudentRecordId",
                table: "StudentProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_RenamedRoom_RoomId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProfile",
                table: "StudentProfile");

            migrationBuilder.RenameTable(
                name: "StudentProfile",
                newName: "StudentProfiles");

            migrationBuilder.RenameIndex(
                name: "IX_StudentProfile_StudentRecordId",
                table: "StudentProfiles",
                newName: "IX_StudentProfiles_StudentRecordId");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProfiles",
                table: "StudentProfiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfiles_Students_StudentRecordId",
                table: "StudentProfiles",
                column: "StudentRecordId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_RenamedRoom_RoomId",
                table: "Students",
                column: "RoomId",
                principalTable: "RenamedRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentProfiles_Students_StudentRecordId",
                table: "StudentProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_RenamedRoom_RoomId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentProfiles",
                table: "StudentProfiles");

            migrationBuilder.RenameTable(
                name: "StudentProfiles",
                newName: "StudentProfile");

            migrationBuilder.RenameIndex(
                name: "IX_StudentProfiles_StudentRecordId",
                table: "StudentProfile",
                newName: "IX_StudentProfile_StudentRecordId");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentProfile",
                table: "StudentProfile",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProfile_Students_StudentRecordId",
                table: "StudentProfile",
                column: "StudentRecordId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_RenamedRoom_RoomId",
                table: "Students",
                column: "RoomId",
                principalTable: "RenamedRoom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
