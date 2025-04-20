using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Queries.Models;

namespace SchoolProject.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentsController(IMediator mediator) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        var response = await mediator.Send(new GetStudentsQuery());
        return Ok(response);
    }
}
