using SchoolProject.Domain.Common;
using ZLinq;

namespace SchoolProject.Core.Mapping.StudentMapping;

public static partial class StudentMapper
{
	public static IEnumerable<GetStudentsDto> ToDtoList(this IEnumerable<Student> students)
		=> students.Select(student =>
			new GetStudentsDto
			(
				student.StudID,
				LocalizeEntity.Localize(student.NameAr, student.NameEn),
				student.Address,
				student.Phone,
				LocalizeEntity.Localize(student.Department.DNameAr, student.Department.DNameEn),
				[
					.. student.Subjects.AsValueEnumerable()
						.Select(subj => LocalizeEntity
							.Localize(subj.SubjectNameAr, subj.SubjectNameEn))!
				]
			)
		);
}