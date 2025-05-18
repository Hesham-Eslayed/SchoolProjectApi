using SchoolProject.Core.Features.Students.Commands.Models;

namespace SchoolProject.Core.Mapping.StudentMapping.CommandMapping;

public partial class StudentMapper
{
    public static void Update(this Student student, EditStudentCommand studentCommand)
    {
        student.Name = studentCommand.Name ?? student.Name;
        student.DID = studentCommand.DepartmentId ?? student.DID;
        student.Address = studentCommand.Address ?? student.Address;
        student.Phone = studentCommand.Phone ?? student.Phone;
    }
}