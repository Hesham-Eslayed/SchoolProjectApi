using FluentValidation;

using SchoolProject.Core.Features.Students.Commands.Models;

namespace SchoolProject.Core.Features.Students.Commands.Validations;

public class AddStudentValidator : AbstractValidator<AddStudentCommand>
{
    private readonly IStudentService _studentService;

    public AddStudentValidator(IStudentService studentService)
    {
        ApplyValidationRules();
        ApplyCustomValidation();
        this._studentService = studentService;
    }

    private void ApplyCustomValidation()
        => RuleFor(x => x.Name)
                .MustAsync(async (key, CancellationToken)
                    => !await _studentService.IsNameExistsAsync(key))
                    .WithMessage("{PropertyValue} is already exists");

    private void ApplyValidationRules()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} must not be null or empty")
            .Length(3, 50)
            .WithMessage("{PropertyName}  must be between {MinLength} and {MaxLength} characters.");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("{PropertyName} must not be null or empty")
            .Length(3, 50)
            .WithMessage("{PropertyName}  must be between {MinLength} and {MaxLength} characters.");
    }
}