using SchoolProject.Core.Features.Students.Commands.Models;

namespace SchoolProject.Core.Mapping.StudentMapping.CommandMapping;

public static partial class StudentMapper
{
    public static Student ToStudent(this AddStudentCommand student) => new()
    {
        Address = student.Address!,
        NameEn = student.Name!,
        Phone = student.Phone!,
        DID = student.DepartmentId
    };
}