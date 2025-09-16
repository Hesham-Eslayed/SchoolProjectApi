using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentications.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Domain.Identity;

namespace SchoolProject.Core.Features.Authentications.Handlers;

public class AuthenticationCommandHandler(
	IStringLocalizer<SharedResources> stringLocalizer,
	SignInManager<User> signInManager,
	IAuthenticationService authenticationService)
	: ResponseHandler(stringLocalizer), IRequestHandler<SignInCommand, Response<string>>
{

	public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
	{
		var user = await signInManager.UserManager.FindByNameAsync(request.UserName);

		if (user is null) return BadRequest<string>("User not found");

		var signInResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

		if (!signInResult.Succeeded) return BadRequest<string>("Invalid login");

		string jwtToken = await authenticationService.GetJwtTokenAsync(user, cancellationToken);

		return Success(jwtToken);
	}
}