using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Domain.Identity;

namespace SchoolProject.Core.Mapping.UserMapping;

public static partial class UserMapper
{
	public static User TOModel(this AddUserCommand command) => new()
	{
		Email = command.Email,
		UserName = command.UserName,
		Address = command.Address,
		Country = command.Country,
		PhoneNumber = command.PhoneNumber
	};
}