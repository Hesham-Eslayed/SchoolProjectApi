using SchoolProject.Domain.Identity;

namespace SchoolProject.Service.Interfaces;

public interface IAuthenticationService
{
	Task<string> GetJwtTokenAsync(User user, CancellationToken ct = default);
}