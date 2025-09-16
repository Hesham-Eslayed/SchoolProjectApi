using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Domain.Helpers;
using SchoolProject.Domain.Identity;

namespace SchoolProject.Service.Implementations;

public class AuthenticationService(UserManager<User> userManager, IOptionsSnapshot<JwtSettings> jwtSetting) : IAuthenticationService
{

	public async Task<string> GetJwtTokenAsync(User user, CancellationToken ct = default)
	{

		List<Claim> claims =
		[
			new(ClaimTypes.Email, user.Email!),
			new(ClaimTypes.Name, user.UserName!),
			new(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new(ClaimTypes.MobilePhone, user.PhoneNumber ?? "")
		];

		foreach (var claim in claims)
			Console.WriteLine(claim.Value);

		var userRoles = await userManager.GetRolesAsync(user);
		var userClaims = await userManager.GetClaimsAsync(user);

		claims.AddRange(userClaims);

		claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

		var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSetting.Value.Key!));

		var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(jwtSetting.Value.Issuer, jwtSetting.Value.Audience, claims,
			expires: DateTime.UtcNow.AddMinutes(jwtSetting.Value.ExpiresInMinutes), signingCredentials: credentials);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}