using SchoolProject.Core.Features.Users.Queries.Responses;
using SchoolProject.Domain.Identity;

namespace SchoolProject.Core.Mapping.UserMapping;

public static partial class UserMapper
{

	public static GetUserByIdResponse ToGetUserByIdResponse(this User user)
		=> new(user.Id, user.UserName!, user.Email!, user.PhoneNumber, user.Address, user.Country);
}