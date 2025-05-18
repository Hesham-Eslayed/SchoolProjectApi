using System.Reflection;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviors;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace SchoolProject.Core;

public static class ModuleCoreDependencies
{
    public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
    {
        // mediator configuration
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        // Get Validators
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddFluentValidationAutoValidation(op
            => op.OverrideDefaultResultFactoryWith<CustomValidationResultFactory>());

        services.Configure<ApiBehaviorOptions>(options =>
               options.InvalidModelStateResponseFactory = context =>
               {
                   var errors = context.ModelState
                        .Where(x => x.Value!.Errors.Count > 0)
                        .SelectMany(err => err.Value!.Errors
                                 .Select(r => new ValidationFailure(err.Key, r.ErrorMessage)));

                   throw new ValidationException(errors);
               }
               );

        return services;
    }
}