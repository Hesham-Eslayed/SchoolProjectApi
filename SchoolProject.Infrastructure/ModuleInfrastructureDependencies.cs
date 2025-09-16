using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Domain.Helpers;
using SchoolProject.Domain.Identity;
using SchoolProject.Domain.Interfaces.Persistence;
using SchoolProject.Infrastructure.InfarstructureBases;

namespace SchoolProject.Infrastructure;

public static class ModuleInfrastructureDependencies
{
	public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<IStudentRepository, StudentRepository>();
		services.AddScoped<IDepartmentRepository, DepartmentRepository>();
		services.AddScoped<IInstructorRepository, InstructorRepository>();
		services.AddScoped<ISubjectRepository, SubjectRepository>();
		services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
		services.AddIdentityService(configuration);

		return services;
	}

	private static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
	{

		services.AddIdentity<User, IdentityRole<int>>(op =>
			{
				op.Password.RequiredLength = 3;
				op.Password.RequiredUniqueChars = 0;
				op.User.RequireUniqueEmail = true;
				op.Password.RequireNonAlphanumeric = false;
				op.Password.RequireLowercase = false;
				op.Password.RequireUppercase = false;

			})
			.AddEntityFrameworkStores<AppDbContext>();

		var jwtSettings = configuration.GetSection(JwtSettings.Name).Get<JwtSettings>() ??
		                  throw new NullReferenceException($"{nameof(JwtSettings)} not found");

		services.AddAuthentication(op =>
			{
				op.DefaultAuthenticateScheme = op.DefaultChallengeScheme =
					op.DefaultForbidScheme = op.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(op =>
			{
				op.SaveToken = true;
				op.RequireHttpsMetadata = false;

				op.TokenValidationParameters = new()
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings!.Key!)),
					ClockSkew = TimeSpan.Zero,
					ValidAudience = jwtSettings.Audience,
					ValidIssuer = jwtSettings.Issuer

				};
			});

		return services;
	}
}