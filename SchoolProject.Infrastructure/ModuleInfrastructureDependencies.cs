using Microsoft.AspNetCore.Identity;
using SchoolProject.Domain.Identity;
using SchoolProject.Domain.Interfaces.Persistence;
using SchoolProject.Infrastructure.InfarstructureBases;

namespace SchoolProject.Infrastructure;

public static class ModuleInfrastructureDependencies
{
	public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
	{
		services.AddScoped<IStudentRepository, StudentRepository>();
		services.AddScoped<IDepartmentRepository, DepartmentRepository>();
		services.AddScoped<IInstructorRepository, InstructorRepository>();
		services.AddScoped<ISubjectRepository, SubjectRepository>();
		services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

		return services;
	}

	public static IServiceCollection AddIdentity(this IServiceCollection services)
	{

		services.AddIdentityCore<User>(op =>
			{
				op.Password.RequiredLength = 3;
				op.Password.RequiredUniqueChars = 0;
				op.User.RequireUniqueEmail = true;
				op.Password.RequireNonAlphanumeric = false;


			})
			.AddRoles<IdentityRole<int>>()
			.AddEntityFrameworkStores<AppDbContext>();

		return services;
	}
}