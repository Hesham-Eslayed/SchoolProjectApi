

namespace SchoolProject.Core.Mapping.StudentMapping.QueryMapping;
public static partial class StudentMapper
{
    public static GetStudentDto ToDto(this Student student)
    {
        return new GetStudentDto(student.StudID, student.Name, student.Address,
            student.Phone, student.Department!.DName,
            [.. student.Subjects.Select(subj => subj.SubjectName)]);
    }
}
