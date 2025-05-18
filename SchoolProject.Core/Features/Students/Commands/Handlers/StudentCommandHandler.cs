using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Mapping.StudentMapping.CommandMapping;

namespace SchoolProject.Core.Features.Students.Commands.Handlers;

public class StudentCommandHandler(IStudentService studentService) :
    ResponseHandler,
    IRequestHandler<AddStudentCommand, Response<string>>
{
    public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        var student = request.ToStudent();
        Student? result = await studentService.AddAsync(student);

        return result is not null ? Created("") : BadRequest<string>("Already Exists");
    }
}