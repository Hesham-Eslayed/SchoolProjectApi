namespace SchoolProject.Core.Features.Users.Commands.Models;

public record UpdateUserCommand(
	int Id,
	string UserName,
	string Email,
	string? Address,
	string? Country,
	string? PhoneNumber)
	: IRequest<Response<string>>;