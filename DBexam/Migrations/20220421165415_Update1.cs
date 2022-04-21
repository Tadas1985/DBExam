using Microsoft.EntityFrameworkCore.Migrations;

namespace DBexam.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentLecture_Lecture_LecturesId",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Student_StudentId",
                table: "Lecture");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_DepartmentSet_DPId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecture",
                table: "Lecture");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "StudentSet");

            migrationBuilder.RenameTable(
                name: "Lecture",
                newName: "LectureSet");

            migrationBuilder.RenameIndex(
                name: "IX_Student_DPId",
                table: "StudentSet",
                newName: "IX_StudentSet_DPId");

            migrationBuilder.RenameIndex(
                name: "IX_Lecture_StudentId",
                table: "LectureSet",
                newName: "IX_LectureSet_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSet",
                table: "StudentSet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LectureSet",
                table: "LectureSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_LectureSet_LecturesId",
                table: "DepartmentLecture",
                column: "LecturesId",
                principalTable: "LectureSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LectureSet_StudentSet_StudentId",
                table: "LectureSet",
                column: "StudentId",
                principalTable: "StudentSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_DepartmentLecture_LectureSet_LecturesId",
                table: "DepartmentLecture");

            migrationBuilder.DropForeignKey(
                name: "FK_LectureSet_StudentSet_StudentId",
                table: "LectureSet");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSet_DepartmentSet_DPId",
                table: "StudentSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSet",
                table: "StudentSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LectureSet",
                table: "LectureSet");

            migrationBuilder.RenameTable(
                name: "StudentSet",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "LectureSet",
                newName: "Lecture");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSet_DPId",
                table: "Student",
                newName: "IX_Student_DPId");

            migrationBuilder.RenameIndex(
                name: "IX_LectureSet_StudentId",
                table: "Lecture",
                newName: "IX_Lecture_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecture",
                table: "Lecture",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentLecture_Lecture_LecturesId",
                table: "DepartmentLecture",
                column: "LecturesId",
                principalTable: "Lecture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Student_StudentId",
                table: "Lecture",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_DepartmentSet_DPId",
                table: "Student",
                column: "DPId",
                principalTable: "DepartmentSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
