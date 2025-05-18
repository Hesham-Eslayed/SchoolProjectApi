using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Shared;

namespace SchoolProject.Core.Features.Students.Commands.Validations;

public class AddStudentValidator : AbstractValidator<AddStudentCommand>
{
    private readonly IStudentService _studentService;

    public AddStudentValidator(IStudentService studentService)
    {
        Include(new BaseStudentCommandValidator());
        ApplyValidationRules();
        ApplyCustomValidation();
        this._studentService = studentService;
    }

    private void ApplyCustomValidation()
    {
        RuleFor(x => x.Name)
                    .MustAsync(async (key, CancellationToken)
                        => !await _studentService.IsNameExistAsync(key!))
                        .WithMessage("{PropertyValue} is already exists");

        RuleFor(x => x.Phone)
            .MustAsync(async (key, CancellationToken)
            => !await _studentService.IsPhoneExistAsync(key!))
                         .WithMessage("{PropertyValue} already exists");
    }

    private void ApplyValidationRules()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} must not be null or empty");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("{PropertyName} must not be null or empty");

        RuleFor(x => x.Phone)
           .NotEmpty()
           .WithMessage("{PropertyName} must not be null or empty");
    }
}