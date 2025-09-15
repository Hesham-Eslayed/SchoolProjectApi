using SchoolProject.Api.Bases;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Features.Users.Queries.Models;

namespace SchoolProject.Api.Controllers;

public class UsersController : AppControllerBase
{

	[HttpGet(Router.User.Paginated)]
	public async Task<IActionResult> GetUsersPaginated(int pageNumber, int pageSize, CancellationToken cancellationToken)
		=> Ok(await Mediator.Send(new GetUserListQuery(pageNumber, pageSize), cancellationToken));

	[HttpPost(Router.User.Add)]
	public async Task<IActionResult> Create([FromBody] AddUserCommand command, CancellationToken cancellationToken)
		=> NewResult(await Mediator.Send(command, cancellationToken));

	[HttpGet(Router.User.GetById)]
	public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
		=> NewResult(await Mediator.Send(new GetUserByIdQuery(id), cancellationToken));

	[HttpPut(Router.User.Update)]
	public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command, CancellationToken cancellationToken)
		=> NewResult(await Mediator.Send(command, cancellationToken));

	[HttpDelete(Router.User.Delete)]
	public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
		=> NewResult(await Mediator.Send(new DeleteUserCommand(id), cancellationToken));
}