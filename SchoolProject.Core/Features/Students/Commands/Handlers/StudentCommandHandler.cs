using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Mapping.StudentMapping;
using SchoolProject.Core.Mapping.StudentMapping.CommandMapping;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Students.Commands.Handlers;

public class StudentCommandHandler(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
	: ResponseHandler(stringLocalizer),
	  IRequestHandler<AddStudentCommand, Response<GetStudentDto>>,
	  IRequestHandler<EditStudentCommand, Response<Unit>>,
	  IRequestHandler<DeleteStudentCommand, Response<Unit>>
{
	public async Task<Response<GetStudentDto>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
	{
		var student = request.ToStudent();

		var added = await studentService.AddAsync(student) ?? throw new("Phone number already exists");

		var result = await studentService.GetStudentByIdWithIncludeAsync(added.StudID);

		return Created(result!.ToDto());
	}

	public async Task<Response<Unit>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
	{
		var student = await studentService.GetStudentByIdAsync(request.Id);

		if (student is null)
			return NotFound<Unit>();

		return await studentService.DeleteAsync(student)
			? Deleted<Unit>()
			: throw new("Something went wrong while deleting student");

	}

	public async Task<Response<Unit>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
	{
		var student = await studentService.GetStudentByIdWithIncludeAsync(request.Id);

		if (student is null)
			return NotFound<Unit>();

		student.Update(request);

		return await studentService.UpdateAsync(student)
			? NoContent<Unit>()
			: throw new("Something went wrong while updating student");
	}
}