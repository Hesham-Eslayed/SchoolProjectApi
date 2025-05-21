using SchoolProject.Core.Features.Students.Commands.Models;

namespace SchoolProject.Core.Mapping.StudentMapping.CommandMapping;

public partial class StudentMapper
{
    public static void Update(this Student student, EditStudentCommand studentCommand)
    {
        student.NameEn = studentCommand.NameEn ?? student.NameEn;
        student.NameAr = studentCommand.NameAr ?? student.NameAr;
        student.DID = studentCommand.DepartmentId ?? student.DID;
        student.Address = studentCommand.Address ?? student.Address;
        student.Phone = studentCommand.Phone ?? student.Phone;
    }
}