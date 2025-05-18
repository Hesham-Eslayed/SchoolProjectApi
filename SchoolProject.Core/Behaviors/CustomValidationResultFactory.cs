using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;

namespace SchoolProject.Core.Behaviors;

public class CustomValidationResultFactory : IFluentValidationAutoValidationResultFactory
{
    public IActionResult CreateActionResult(ActionExecutingContext context, ValidationProblemDetails? validationProblemDetails)
    {

        var errors = context.ModelState
            .Where(x => x.Value!.Errors.Count > 0)
            .SelectMany(err => err.Value!.Errors
                             .Select(r => new ValidationFailure(err.Key, r.ErrorMessage)));

        throw new ValidationException(errors);

    }
}