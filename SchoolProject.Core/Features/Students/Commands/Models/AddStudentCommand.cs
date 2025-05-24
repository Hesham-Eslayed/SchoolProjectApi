using SchoolProject.Core.Features.Students.Shared;

namespace SchoolProject.Core.Features.Students.Commands.Models;

public class AddStudentCommand : BaseStudentCommand, IRequest<Response<int>>
{
}