using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Mapping.UserMapping;
using SchoolProject.Core.Resources;
using SchoolProject.Domain.Identity;

namespace SchoolProject.Core.Features.Users.Commands.Handlers;

public class UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, UserManager<User> userManager)
	: ResponseHandler(stringLocalizer), IRequestHandler<AddUserCommand, Response<Unit>>,
	  IRequestHandler<UpdateUserCommand, Response<Unit>>, IRequestHandler<DeleteUserCommand, Response<Unit>>,
	  IRequestHandler<ChangeUserPasswordCommand, Response<Unit>>
{

	public async Task<Response<Unit>> Handle(AddUserCommand request, CancellationToken cancellationToken)
	{
		var email = await userManager.FindByEmailAsync(request.Email);

		if (email is not null) return BadRequest<Unit>("Email is invalid");

		var userName = await userManager.FindByNameAsync(request.UserName);

		if (userName is not null) return BadRequest<Unit>("UserName is invalid");

		var identityUser = request.TOModel();

		var createdUser = await userManager.CreateAsync(identityUser, request.Password);

		return !createdUser.Succeeded ? BadRequest<Unit>(createdUser.Errors.FirstOrDefault()!.Description) : Created(Unit.Value);

	}

	public async Task<Response<Unit>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
	{
		var user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

		if (user is null) return BadRequest<Unit>("User Id or Password is invalid");

		bool validPassword = await userManager.CheckPasswordAsync(user, request.CurrentPassword);

		if (!validPassword) return BadRequest<Unit>("User Id or Password is invalid");

		var updatedResult = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

		return !updatedResult.Succeeded ? BadRequest<Unit>(updatedResult.Errors.FirstOrDefault()?.Description) : NoContent<Unit>();

	}

	public async Task<Response<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByIdAsync(request.Id.ToString());

		if (user is null) return NotFound<Unit>();

		var deleted = await userManager.DeleteAsync(user);

		return !deleted.Succeeded ? BadRequest<Unit>(deleted.Errors.FirstOrDefault()?.Description) : Deleted<Unit>();

	}

	public async Task<Response<Unit>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByIdAsync(request.Id.ToString());

		if (user is null) return NotFound<Unit>();

		bool userNameExists =
			await userManager.Users.AnyAsync(x => x.UserName == request.UserName && x.Id != request.Id, cancellationToken);

		if (userNameExists) return BadRequest<Unit>("UserName is invalid");

		bool emailExists = await userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != request.Id, cancellationToken);

		if (emailExists) return BadRequest<Unit>("Email is invalid");

		user.UpdateFromUpdateCommand(request);

		var result = await userManager.UpdateAsync(user);

		return !result.Succeeded ? BadRequest<Unit>(result.Errors.FirstOrDefault()?.Description) : NoContent<Unit>();

	}
}