using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Mapping.StudentMapping.CommandMapping;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Students.Commands.Handlers;

public class StudentCommandHandler(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer) :
    ResponseHandler(stringLocalizer),
    IRequestHandler<AddStudentCommand, Response<int>>,
    IRequestHandler<EditStudentCommand, Response<Unit>>,
    IRequestHandler<DeleteStudentCommand, Response<Unit>>
{
    public async Task<Response<int>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        var student = request.ToStudent();

        var result = await studentService.AddAsync(student)
            ?? throw new Exception("Phone number already exists");

        return Created(result.StudID);
    }

    public async Task<Response<Unit>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentService.GetStudentByIdWithIncludeAsync(request.Id);

        if (student is null)
            return NotFound<Unit>();

        student.Update(request);

        return await studentService.UpdateAsync(student)
            ? NoContent<Unit>()
            : throw new Exception("Something went wrong while updating student");
    }

    public async Task<Response<Unit>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await studentService.GetStudentByIdAsync(request.Id);


        if (student is null)
            return NotFound<Unit>();

        return await studentService.DeleteAsync(student) ? Deleted<Unit>()
            : throw new Exception("Something went wrong while deleting student");

    }
}