using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Mapping.StudentMapping.CommandMapping;

namespace SchoolProject.Core.Features.Students.Commands.Handlers;

public class StudentCommandHandler(IStudentService studentService) :
    ResponseHandler,
    IRequestHandler<AddStudentCommand, Response<string>>,
    IRequestHandler<EditStudentCommand, Response<Unit>>,
    IRequestHandler<DeleteStudentCommand, Response<Unit>>
{
    public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        var student = request.ToStudent();

        var result = await studentService.AddAsync(student)
            ?? throw new Exception("Phone number already exists");

        return Created("");
    }

    public async Task<Response<Unit>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentService.GetStudentByIdWithIncludeAsync(request.Id)
            ?? throw new KeyNotFoundException($"No Student with id {request.Id} found");

        student.Update(request);

        return await studentService.UpdateAsync(student)
            ? NoContent<Unit>("Updated Successfully")
            : throw new Exception("Something went wrong while updating student");
    }

    public async Task<Response<Unit>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentService.GetStudentByIdAsync(request.Id)
            ?? throw new KeyNotFoundException($"No Student with id {request.Id}");

        return await studentService.DeleteAsync(student) ? NoContent<Unit>()
            : throw new Exception("Something went wrong while deleting student");

    }
}