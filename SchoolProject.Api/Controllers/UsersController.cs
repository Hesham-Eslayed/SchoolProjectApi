using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Users.Commands.Models;

namespace SchoolProject.Api.Controllers;

public class UsersController : AppControllerBase
{
	[HttpPost(Router.User.Add)]
	public async Task<IActionResult> Create(AddUserCommand command, CancellationToken cancellationToken)
	{
		var response = await Mediator.Send(command, cancellationToken);

		return NewResult(response);
	}
}