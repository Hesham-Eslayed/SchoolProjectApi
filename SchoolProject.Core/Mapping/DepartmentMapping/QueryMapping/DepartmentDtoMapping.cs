using SchoolProject.Core.Features.Departments.Queries.DTOs;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Common;
using ZLinq;

namespace SchoolProject.Core.Mapping.DepartmentMapping.QueryMapping;

public static class DepartmentMapper
{
	public static DepartmentDto ToDepartmentDto(this Department department, PaginatedResult<StudentDto> paginatedStudents)
	{
		return new(
			department.DID,
			LocalizeEntity.Localize(department.DNameAr, department.DNameEn),
			department.ManagerId!.Value,
			LocalizeEntity.Localize(department?.Manager?.NameAr, department?.Manager?.NameEn),
			paginatedStudents,
			[.. department!.Subjects.AsValueEnumerable().Select(x => x.ToDeptSubjectDto())],
			[.. department.Instructors.AsValueEnumerable().Select(x => x.ToDeptInstructorDto())]
		);
	}

	public static StudentDto ToDeptStudentDto(this Student student)
		=> new(student.StudID, LocalizeEntity.Localize(student.NameAr, student.NameEn));

	public static SubjectDto ToDeptSubjectDto(this Subject subject)
		=> new(subject.SubID, LocalizeEntity.Localize(subject.SubjectNameAr, subject.SubjectNameEn));

	public static InstructorDto ToDeptInstructorDto(this Instructor instructor)
		=> new(instructor.InsId, LocalizeEntity.Localize(instructor.NameAr, instructor.NameEn));

	public static IQueryable<StudentDto> ToStudentDtoQuery(this IQueryable<Student> studentsQuery)
	{
		var query = studentsQuery
			.Select(x => new StudentDto(
				x.StudID,
				LocalizeEntity.Localize(x.NameAr, x.NameEn)));

		return query;
	}
}