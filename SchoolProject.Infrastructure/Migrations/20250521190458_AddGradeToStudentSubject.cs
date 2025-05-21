using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGradeToStudentSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "StudentsSubjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentStudID",
                table: "StudentsSubjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsSubjects_StudentStudID",
                table: "StudentsSubjects",
                column: "StudentStudID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsSubjects_Students_StudentStudID",
                table: "StudentsSubjects",
                column: "StudentStudID",
                principalTable: "Students",
                principalColumn: "StudID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsSubjects_Students_StudentStudID",
                table: "StudentsSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentsSubjects_StudentStudID",
                table: "StudentsSubjects");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentsSubjects");

            migrationBuilder.DropColumn(
                name: "StudentStudID",
                table: "StudentsSubjects");
        }
    }
}
