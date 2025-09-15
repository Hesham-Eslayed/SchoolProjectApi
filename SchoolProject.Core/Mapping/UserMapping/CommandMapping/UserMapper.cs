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

	public static User UpdateFromUpdateCommand(this User user, UpdateUserCommand command)
	{
		user.Email = command.Email;
		user.UserName = command.UserName;
		user.Address = command.Address;
		user.Country = command.Country;
		user.PhoneNumber = command.PhoneNumber;

		return user;
	}
}