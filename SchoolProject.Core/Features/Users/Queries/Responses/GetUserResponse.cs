namespace SchoolProject.Core.Features.Users.Queries.Responses;

public record GetUserResponse(int Id, string UserName, string Email, string? PhoneNumber, string? Address, string? Country);