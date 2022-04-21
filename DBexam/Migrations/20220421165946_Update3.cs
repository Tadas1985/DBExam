using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBexam.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LectureSet_StudentSet_StudentId",
                table: "LectureSet");

            migrationBuilder.DropIndex(
                name: "IX_LectureSet_StudentId",
                table: "LectureSet");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "LectureSet");

            migrationBuilder.CreateTable(
                name: "LectureStudent",
                columns: table => new
                {
                    LecturesListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureStudent", x => new { x.LecturesListId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_LectureStudent_LectureSet_LecturesListId",
                        column: x => x.LecturesListId,
                        principalTable: "LectureSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LectureStudent_StudentSet_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "StudentSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LectureStudent_StudentsId",
                table: "LectureStudent",
                column: "StudentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LectureStudent");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "LectureSet",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LectureSet_StudentId",
                table: "LectureSet",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_LectureSet_StudentSet_StudentId",
                table: "LectureSet",
                column: "StudentId",
                principalTable: "StudentSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
