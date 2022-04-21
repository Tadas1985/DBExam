using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBexam.Migrations
{
    public partial class Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentStudent");

            migrationBuilder.AddColumn<Guid>(
                name: "DPId",
                table: "StudentSet",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentSet_DPId",
                table: "StudentSet",
                column: "DPId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSet_DepartmentSet_DPId",
                table: "StudentSet",
                column: "DPId",
                principalTable: "DepartmentSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSet_DepartmentSet_DPId",
                table: "StudentSet");

            migrationBuilder.DropIndex(
                name: "IX_StudentSet_DPId",
                table: "StudentSet");

            migrationBuilder.DropColumn(
                name: "DPId",
                table: "StudentSet");

            migrationBuilder.CreateTable(
                name: "DepartmentStudent",
                columns: table => new
                {
                    DepartmentListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentStudent", x => new { x.DepartmentListId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_DepartmentStudent_DepartmentSet_DepartmentListId",
                        column: x => x.DepartmentListId,
                        principalTable: "DepartmentSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentStudent_StudentSet_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "StudentSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentStudent_StudentsId",
                table: "DepartmentStudent",
                column: "StudentsId");
        }
    }
}
