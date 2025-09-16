using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Authentications.Commands.Models;

namespace SchoolProject.Api.Controllers;

public class AuthenticationsController : AppControllerBase
{
	[HttpPost(Router.Authentication.SignIn)]
	public async Task<IActionResult> Create([FromBody] SignInCommand command, CancellationToken cancellationToken)
	{
		var result = await Mediator.Send(command, cancellationToken);

		return NewResult(result);
	}
}