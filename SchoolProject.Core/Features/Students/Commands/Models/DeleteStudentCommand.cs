namespace SchoolProject.Core.Features.Students.Commands.Models;

public record class DeleteStudentCommand(int Id) : IRequest<Response<Unit>>;