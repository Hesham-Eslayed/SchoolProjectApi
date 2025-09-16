namespace SchoolProject.Domain.Helpers;

public class JwtSettings
{
	public const string Name = "JwtSettings";

	public string? Issuer { get; set; }

	public string? Audience { get; set; }

	public string? Key { get; set; }

	public double ExpiresInMinutes { get; set; }
}