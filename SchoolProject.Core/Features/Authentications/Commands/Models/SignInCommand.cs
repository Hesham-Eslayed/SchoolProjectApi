namespace SchoolProject.Core.Features.Authentications.Commands.Models;

public record SignInCommand(string UserName, string Password) : IRequest<Response<string>>;