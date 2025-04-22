namespace SchoolProject.Core.Features.Students.Queries.DTOs;
public record GetStudentDto(int StudID, string Name, string Address, string Phone,
    string DepartmentName, IReadOnlyList<string> Subjects);
