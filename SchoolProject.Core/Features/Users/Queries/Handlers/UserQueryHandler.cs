using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Queries.Models;
using SchoolProject.Core.Features.Users.Queries.Responses;
using SchoolProject.Core.Mapping.UserMapping;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Identity;

namespace SchoolProject.Core.Features.Users.Queries.Handlers;

public class UserQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, UserManager<User> userManager)
	: ResponseHandler(stringLocalizer), IRequestHandler<GetUserListQuery, PaginatedResult<GetUserResponse>>,
	  IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
{

	public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
	{
		var user = await userManager.FindByIdAsync(request.Id.ToString());

		if (user is null) return NotFound<GetUserByIdResponse>("User not found");

		var result = user.ToGetUserByIdResponse();

		return Success(result);
	}

	public async Task<PaginatedResult<GetUserResponse>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
	{
		var users = userManager.Users;

		var paginatedList = await users.ToGetUserResponse().ToPaginatedListAsync(request.PageNumber, request.PageSize);

		return paginatedList;

	}
}