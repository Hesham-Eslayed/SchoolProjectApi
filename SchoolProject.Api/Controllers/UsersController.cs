using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Features.Users.Queries.Models;

namespace SchoolProject.Api.Controllers;

public class UsersController : AppControllerBase
{
	[HttpPost(Router.User.Add)]
	public async Task<IActionResult> Create(AddUserCommand command, CancellationToken cancellationToken)
		=> NewResult(await Mediator.Send(command, cancellationToken));

	[HttpPost(Router.User.GetById)]
	public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken)
		=> NewResult(await Mediator.Send(new GetUserByIdQuery(Id), cancellationToken));
}