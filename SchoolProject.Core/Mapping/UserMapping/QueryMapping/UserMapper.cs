using SchoolProject.Core.Features.Users.Queries.Responses;
using SchoolProject.Domain.Identity;

namespace SchoolProject.Core.Mapping.UserMapping;

public static partial class UserMapper
{

	public static IQueryable<GetUserResponse> ToGetUserResponse(this IQueryable<User> users)
		=> users.Select(x => new GetUserResponse(x.Id, x.UserName!, x.Email!, x.PhoneNumber, x.Address, x.Country));
}