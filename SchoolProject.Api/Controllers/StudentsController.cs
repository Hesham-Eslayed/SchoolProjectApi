using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;

namespace SchoolProject.Api.Controllers;

[ApiController]
public class StudentsController : AppControllerBase
{
    [HttpGet(Router.Student.List)]
    [EndpointDescription("Get All students")]
    [ProducesResponseType(200, Type = typeof(Response<IEnumerable<GetStudentsDto>>))]
    public async Task<IActionResult> GetStudents()
    {
        var response = await Mediator.Send(new GetStudentsQuery());
        return NewResult(response);
    }

    [HttpGet(Router.Student.GetById)]
    [EndpointDescription("Get the student by id")]
    [ProducesResponseType(200, Type = typeof(Response<GetStudentDto>))]
    public async Task<IActionResult> GetStudent(int id)
    {
        var response = await Mediator.Send(new GetStudentByIdQuery(id));
        return NewResult(response);
    }

    [HttpPost(Router.Student.Add)]
    public async Task<IActionResult> AddStudent(AddStudentCommand student)
    {
        var result = await Mediator.Send(student);

        return NewResult(result);

    }

    [HttpPut(Router.Student.Update)]
    public async Task<IActionResult> UpdateStudent([FromBody] EditStudentCommand studentCommand)
    {
        var result = await Mediator.Send(studentCommand);
        return NewResult(result);
    }
}