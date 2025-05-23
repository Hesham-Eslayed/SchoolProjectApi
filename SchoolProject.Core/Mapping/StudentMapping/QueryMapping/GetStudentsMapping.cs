using SchoolProject.Domain.Common;
using ZLinq;

namespace SchoolProject.Core.Mapping.StudentMapping.QueryMapping;

public static partial class StudentMapper
{
    public static IEnumerable<GetStudentsDto> ToDtoList(this IEnumerable<Student> students)
        => students.Select(student =>
            new GetStudentsDto
                    (
                student.StudID,
                ((ILocalizeEntity)student).Localize(student.NameAr, student.NameEn),
                student.Address,
                student.Phone,
                ((ILocalizeEntity)student.Department!).Localize(student.Department.DNameAr, student.Department.DNameEn),
                [.. student.Subjects.AsValueEnumerable().Select(subj => ((ILocalizeEntity)subj)
                .Localize(subj.SubjectNameAr,subj.SubjectNameEn))]
                )
            );
}