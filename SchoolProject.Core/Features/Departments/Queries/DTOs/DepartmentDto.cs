using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Departments.Queries.DTOs;

public record DepartmentDto(
    int Id,
    string? Name,
    int MangerId,
    string? ManagerName,
    PaginatedResult<StudentDto> Students,
    HashSet<SubjectDto> Subjects,
    HashSet<InstructorDto> Instructors);

public record StudentDto(int Id, string? Name);
public record SubjectDto(int Id, string? Name);
public record InstructorDto(int Id, string? Name);