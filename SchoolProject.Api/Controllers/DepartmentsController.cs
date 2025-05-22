using Microsoft.AspNetCore.OutputCaching;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Departments.Queries.Models;

namespace SchoolProject.Api.Controllers;
public class DepartmentsController : AppControllerBase
{
    [OutputCache(Duration = 60)]
    [HttpGet(Router.Department.GetById)]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var result = await Mediator.Send(new GetDepartmentQuery(id));

        return NewResult(result);
    }



}
