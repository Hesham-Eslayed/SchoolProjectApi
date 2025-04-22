using SchoolProject.Core.Features.Students.Queries.DTOs;

namespace SchoolProject.Core.Mapping.StudentMapping.QueryMapping;
public static partial class StudentMapper
{
    public static IEnumerable<GetStudentsDto> ToDtoList(this IEnumerable<Student> students)
    {
        return students.Select(student =>
            new GetStudentsDto
                 (
                student.StudID,
                 student.Name,
                 student.Address,
                student.Phone,
                student.Department!.DName,
                [.. student.Subjects.Select(subj => subj.SubjectName)]
                )
            );
    }
}
