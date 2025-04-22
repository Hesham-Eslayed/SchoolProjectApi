namespace SchoolProject.Api.Controllers;
[ApiController]
[Consumes("application/json")]
[Produces("application/json")]
public class StudentsController(IMediator mediator) : ControllerBase
{

    [HttpGet(Router.Student.List)]
    [EndpointDescription("Get All students")]
    [ProducesResponseType(200, Type = typeof(Response<IEnumerable<GetStudentsDto>>))]
    public async Task<IActionResult> GetStudents()
    {
        var response = await mediator.Send(new GetStudentsQuery());
        return Ok(response);
    }

    [HttpGet(Router.Student.GetById)]
    [EndpointDescription("Get the student by id")]
    [ProducesResponseType(200, Type = typeof(Response<GetStudentDto>))]
    public async Task<IActionResult> GetStudent(int id)
    {
        var response = await mediator.Send(new GetStudentByIdQuery(id));
        return Ok(response);
    }
}
