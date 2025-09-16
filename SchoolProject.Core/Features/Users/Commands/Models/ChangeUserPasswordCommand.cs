namespace SchoolProject.Core.Features.Users.Commands.Models;

public record ChangeUserPasswordCommand(int Id, string CurrentPassword, string NewPassword, string ConfirmPassword)
	: IRequest<Response<Unit>>;