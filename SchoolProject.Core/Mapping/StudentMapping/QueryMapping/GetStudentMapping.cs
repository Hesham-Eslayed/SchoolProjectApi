using ZLinq;

namespace SchoolProject.Core.Mapping.StudentMapping.QueryMapping;

public static partial class StudentMapper
{
    public static GetStudentDto ToDto(this Student student)
    {
        return new GetStudentDto(
            student.StudID,
            student.Localize(student.NameAr, student.NameEn),
            student.Address,
            student.Phone,
            student.Department!.Localize(student.Department.DNameAr, student.Department.DNameEn),
            [.. student.Subjects.AsValueEnumerable().Select(subj => subj.SubjectNameEn)]);
    }
}