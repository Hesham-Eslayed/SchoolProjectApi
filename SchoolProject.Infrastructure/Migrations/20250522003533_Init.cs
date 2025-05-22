using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations;

/// <inheritdoc />
public partial class Init : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Subjects",
            columns: table => new
            {
                SubID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                SubjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Period = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Subjects", x => x.SubID));

        migrationBuilder.CreateTable(
            name: "Departments",
            columns: table => new
            {
                DID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                DNameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                DNameAr = table.Column<string>(type: "NVarChar(100)", nullable: true),
                ManagerId = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table => table.PrimaryKey("PK_Departments", x => x.DID));

        migrationBuilder.CreateTable(
            name: "DepartmentsSubjects",
            columns: table => new
            {
                DID = table.Column<int>(type: "int", nullable: false),
                SubID = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DepartmentsSubjects", x => new { x.DID, x.SubID });
                table.ForeignKey(
                    name: "FK_DepartmentsSubjects_Departments_DID",
                    column: x => x.DID,
                    principalTable: "Departments",
                    principalColumn: "DID",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_DepartmentsSubjects_Subjects_SubID",
                    column: x => x.SubID,
                    principalTable: "Subjects",
                    principalColumn: "SubID",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Instructors",
            columns: table => new
            {
                InsId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                NameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                Position = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                SupervisorId = table.Column<int>(type: "int", nullable: true),
                Salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                DID = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Instructors", x => x.InsId);
                table.ForeignKey(
                    name: "FK_Instructors_Departments_DID",
                    column: x => x.DID,
                    principalTable: "Departments",
                    principalColumn: "DID",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Instructors_Instructors_SupervisorId",
                    column: x => x.SupervisorId,
                    principalTable: "Instructors",
                    principalColumn: "InsId",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Students",
            columns: table => new
            {
                StudID = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                NameEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                NameAr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                DID = table.Column<int>(type: "int", nullable: false),
                DepartmentDID = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Students", x => x.StudID);
                table.ForeignKey(
                    name: "FK_Students_Departments_DepartmentDID",
                    column: x => x.DepartmentDID,
                    principalTable: "Departments",
                    principalColumn: "DID",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "InstructorsSubjects",
            columns: table => new
            {
                InsId = table.Column<int>(type: "int", nullable: false),
                SubID = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_InstructorsSubjects", x => new { x.InsId, x.SubID });
                table.ForeignKey(
                    name: "FK_InstructorsSubjects_Instructors_InsId",
                    column: x => x.InsId,
                    principalTable: "Instructors",
                    principalColumn: "InsId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_InstructorsSubjects_Subjects_SubID",
                    column: x => x.SubID,
                    principalTable: "Subjects",
                    principalColumn: "SubID",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "StudentsSubjects",
            columns: table => new
            {
                StudID = table.Column<int>(type: "int", nullable: false),
                SubID = table.Column<int>(type: "int", nullable: false),
                Grade = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                StudentStudID = table.Column<int>(type: "int", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StudentsSubjects", x => new { x.StudID, x.SubID });
                table.ForeignKey(
                    name: "FK_StudentsSubjects_Students_StudID",
                    column: x => x.StudID,
                    principalTable: "Students",
                    principalColumn: "StudID",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_StudentsSubjects_Students_StudentStudID",
                    column: x => x.StudentStudID,
                    principalTable: "Students",
                    principalColumn: "StudID");
                table.ForeignKey(
                    name: "FK_StudentsSubjects_Subjects_SubID",
                    column: x => x.SubID,
                    principalTable: "Subjects",
                    principalColumn: "SubID",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Departments_ManagerId",
            table: "Departments",
            column: "ManagerId",
            unique: true,
            filter: "[ManagerId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_DepartmentsSubjects_SubID",
            table: "DepartmentsSubjects",
            column: "SubID");

        migrationBuilder.CreateIndex(
            name: "IX_Instructors_DID",
            table: "Instructors",
            column: "DID");

        migrationBuilder.CreateIndex(
            name: "IX_Instructors_SupervisorId",
            table: "Instructors",
            column: "SupervisorId");

        migrationBuilder.CreateIndex(
            name: "IX_InstructorsSubjects_SubID",
            table: "InstructorsSubjects",
            column: "SubID");

        migrationBuilder.CreateIndex(
            name: "IX_Students_DepartmentDID",
            table: "Students",
            column: "DepartmentDID");

        migrationBuilder.CreateIndex(
            name: "IX_StudentsSubjects_StudentStudID",
            table: "StudentsSubjects",
            column: "StudentStudID");

        migrationBuilder.CreateIndex(
            name: "IX_StudentsSubjects_SubID",
            table: "StudentsSubjects",
            column: "SubID");

        migrationBuilder.AddForeignKey(
            name: "FK_Departments_Instructors_ManagerId",
            table: "Departments",
            column: "ManagerId",
            principalTable: "Instructors",
            principalColumn: "InsId",
            onDelete: ReferentialAction.Restrict);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropForeignKey(
            name: "FK_Departments_Instructors_ManagerId",
            table: "Departments");

        migrationBuilder.DropTable(
            name: "DepartmentsSubjects");

        migrationBuilder.DropTable(
            name: "InstructorsSubjects");

        migrationBuilder.DropTable(
            name: "StudentsSubjects");

        migrationBuilder.DropTable(
            name: "Students");

        migrationBuilder.DropTable(
            name: "Subjects");

        migrationBuilder.DropTable(
            name: "Instructors");

        migrationBuilder.DropTable(
            name: "Departments");
    }
}