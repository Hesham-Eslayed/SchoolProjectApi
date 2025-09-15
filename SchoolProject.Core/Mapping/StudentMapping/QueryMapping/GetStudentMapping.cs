using SchoolProject.Domain.Common;
using ZLinq;

namespace SchoolProject.Core.Mapping.StudentMapping.QueryMapping;

public static partial class StudentMapper
{
	public static GetStudentDto ToDto(this Student student, Department? department = null)
	{
		return new(
			student.StudID,
			LocalizeEntity.Localize(student.NameAr, student.NameEn),
			student.Address,
			student.Phone,
			LocalizeEntity.Localize(
				department?.DNameAr,
				department?.DNameEn) ??
			LocalizeEntity.Localize(
				student.Department?.DNameAr,
				student.Department?.DNameEn),
			[.. student.Subjects.AsValueEnumerable().Select(subj => subj.SubjectNameEn)]);
	}
}