using SchoolProject.Core.Features.Students.Shared;

namespace SchoolProject.Core.Features.Students.Commands.Models;

public class EditStudentCommand() : BaseStudentCommand, IRequest<Response<Unit>>
{
    public int Id { get; set; }
}