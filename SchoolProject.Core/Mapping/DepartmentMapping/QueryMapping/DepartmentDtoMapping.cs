using SchoolProject.Core.Features.Departments.Queries.DTOs;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Common;
using ZLinq;

namespace SchoolProject.Core.Mapping.DepartmentMapping.QueryMapping;

public static partial class DepartmentMapper
{
    public static DepartmentDto ToDepartmentDto(this Department department, PaginatedResult<StudentDto> paginatedStudents)
    {
        return new DepartmentDto(
            department.DID,
            ((ILocalizeEntity)department).Localize(department.DNameAr, department.DNameEn),
            department.ManagerId!.Value,
            ((ILocalizeEntity)department.Manager!).Localize(department.Manager.NameAr, department.Manager.NameEn),
            paginatedStudents,
            [.. department.Subjects.AsValueEnumerable().Select(x => x.ToDeptSubjectDto())],
            [.. department.Instructors.AsValueEnumerable().Select(x => x.ToDeptInstructorDto())]
            );
    }

    public static StudentDto ToDeptStudentDto(this Student student)
        => new(student.StudID, ((ILocalizeEntity)student).Localize(student.NameAr, student.NameEn));

    public static SubjectDto ToDeptSubjectDto(this Subject subject)
        => new(subject.SubID, ((ILocalizeEntity)subject).Localize(subject.SubjectNameAr, subject.SubjectNameEn));

    public static InstructorDto ToDeptInstructorDto(this Instructor instructor)
        => new(instructor.InsId, ((ILocalizeEntity)instructor).Localize(instructor.NameAr, instructor.NameEn));

    public static IQueryable<StudentDto> ToStudentDtoQuery(this IQueryable<Student> studentsQuery)
    {
        var query = studentsQuery
            .Select(x => new StudentDto(
                x.StudID,
                ((ILocalizeEntity)x).Localize(x.NameAr, x.NameEn)));

        return query;
    }
}