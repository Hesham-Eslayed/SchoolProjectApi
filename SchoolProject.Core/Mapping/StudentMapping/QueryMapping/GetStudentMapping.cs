using ZLinq;

namespace SchoolProject.Core.Mapping.StudentMapping.QueryMapping;

public static partial class StudentMapper
{
    public static GetStudentDto ToDto(this Student student)
    {
        return new GetStudentDto(student.StudID, student.NameEn, student.Address,
            student.Phone, student.Department!.DNameEn,
            [.. student.Subjects.AsValueEnumerable().Select(subj => subj.SubjectName)]);
    }
}