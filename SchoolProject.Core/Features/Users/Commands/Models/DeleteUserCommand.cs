namespace SchoolProject.Core.Features.Users.Commands.Models;

public record DeleteUserCommand(int Id) : IRequest<Response<Unit>>;