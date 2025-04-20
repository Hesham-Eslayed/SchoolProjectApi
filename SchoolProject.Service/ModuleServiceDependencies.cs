

namespace SchoolProject.Service;
public static class ModuleServiceDependencies
{
    public static IServiceCollection AddInServiceDependencies(this IServiceCollection services)
    {
        services.AddTransient<IStudentService, StudentServices>();
        return services;
    }
}
