namespace SchoolProject.Service;

public static class ModuleServiceDependencies
{
	public static IServiceCollection AddInServiceDependencies(this IServiceCollection services)
	{
		services.AddScoped<IStudentService, StudentServices>();
		services.AddScoped<IDepartmentService, DepartmentService>();
		services.AddScoped<IAuthenticationService, AuthenticationService>();

		return services;
	}
}