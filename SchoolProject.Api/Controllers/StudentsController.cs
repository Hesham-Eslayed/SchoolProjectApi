using Microsoft.AspNetCore.OutputCaching;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;

namespace SchoolProject.Api.Controllers;

[ApiController]
public class StudentsController : AppControllerBase
{
	[OutputCache(Duration = 60)]
	[HttpGet(Router.Student.List)]
	[EndpointDescription("Get All students")]
	[ProducesResponseType(200, Type = typeof(Response<IEnumerable<GetStudentsDto>>))]
	public async Task<IActionResult> GetStudents()
	{
		var response = await Mediator.Send(new GetStudentsQuery());

		return NewResult(response);
	}

	[OutputCache(Duration = 60)]
	[HttpGet(Router.Student.Paginated)]
	[EndpointDescription("Get students Paginated")]
	[ProducesResponseType(200, Type = typeof(Response<IEnumerable<GetStudentsDto>>))]
	public async Task<IActionResult> GetStudentsPaginated([FromQuery] GetStudentPaginatedListQuery query)
	{
		var response = await Mediator.Send(query);

		return Ok(response);
	}

	[OutputCache(Duration = 60)]
	[HttpGet(Router.Student.GetById)]
	[EndpointDescription("Get the student by id")]
	[ProducesResponseType(200, Type = typeof(Response<GetStudentDto>))]
	public async Task<IActionResult> GetStudent([FromRoute] int id)
	{
		var response = await Mediator.Send(new GetStudentByIdQuery(id));

		return NewResult(response);
	}

	[HttpPost(Router.Student.Add)]
	public async Task<IActionResult> AddStudent(AddStudentCommand student)
	{
		var result = await Mediator.Send(student);

		return CreatedAtAction(nameof(GetStudent), new { id = result.Data!.StudID }, result);

	}

	[HttpPut(Router.Student.Update)]
	public async Task<IActionResult> UpdateStudent([FromBody] EditStudentCommand studentCommand)
	{
		var result = await Mediator.Send(studentCommand);

		return NewResult(result);
	}

	[HttpDelete(Router.Student.Delete)]
	public async Task<IActionResult> DeleteStudent([FromRoute] int id)
	{
		var result = await Mediator.Send(new DeleteStudentCommand(id));

		return NewResult(result);
	}
}