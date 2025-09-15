namespace SchoolProject.Core.Features.Users.Commands.Models;

public record AddUserCommand(
	string UserName,
	string Email,
	string? Address,
	string? Country,
	string Password,
	string ConfirmPassword,
	string? PhoneNumber)
	: IRequest<Response<string>>;