using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Mapping.UserMapping;
using SchoolProject.Core.Resources;
using SchoolProject.Domain.Identity;

namespace SchoolProject.Core.Features.Users.Commands.Handlers;

public class UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, UserManager<User> userManager)
	: ResponseHandler(stringLocalizer), IRequestHandler<AddUserCommand, Response<string>>
{

	public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
	{
		var email = await userManager.FindByEmailAsync(request.Email);

		if (email is not null) return BadRequest<string>("Email is invalid");

		var userName = await userManager.FindByNameAsync(request.UserName);

		if (userName is not null) return BadRequest<string>("UserName is invalid");

		var identityUser = request.TOModel();

		var createdUser = await userManager.CreateAsync(identityUser, request.Password);

		if (!createdUser.Succeeded) return BadRequest<string>(createdUser.Errors.FirstOrDefault()!.Description);

		return Created<string>(null);
	}
}