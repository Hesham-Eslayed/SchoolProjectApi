using SchoolProject.Domain.Common;
using ZLinq;

namespace SchoolProject.Core.Mapping.StudentMapping.QueryMapping;

public static partial class StudentMapper
{
    public static GetStudentDto ToDto(this Student student, Department? department = null)
    {
        return new GetStudentDto(
            student.StudID,
            ((ILocalizeEntity)student).Localize(student.NameAr, student.NameEn),
            student.Address,
            student.Phone,
             (department as ILocalizeEntity)?.Localize(
                 department?.DNameAr,
                 department?.DNameEn)
                ?? (student.Department as ILocalizeEntity)?.Localize(
                    student.Department?.DNameAr,
                    student.Department?.DNameEn),
            [.. student.Subjects.AsValueEnumerable().Select(subj => subj.SubjectNameEn)]);
    }
}