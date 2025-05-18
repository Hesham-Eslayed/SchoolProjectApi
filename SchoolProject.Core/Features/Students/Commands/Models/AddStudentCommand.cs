namespace SchoolProject.Core.Features.Students.Commands.Models;
public record AddStudentCommand(string Name, string Phone, string Address, int DepartmentId) : IRequest<Response<string>>;