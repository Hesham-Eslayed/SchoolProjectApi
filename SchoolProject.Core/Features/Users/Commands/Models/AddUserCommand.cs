namespace SchoolProject.Core.Features.User.Commands.Handlers;

public record AddUserCommand(
	string UserName,
	string Email,
	string? Address,
	string? Country,
	string Password,
	string ConfirmPassword,
	string? PhoneNumber)
	: IRequest<Response<string>>;