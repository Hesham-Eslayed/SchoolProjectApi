namespace SchoolProject.Core.Features.Students.Shared;

public class BaseStudentCommandValidator : AbstractValidator<BaseStudentCommand>
{
    public BaseStudentCommandValidator()
    {
        ApplyValidationRules();
    }


    private void ApplyValidationRules()
    {
        RuleFor(x => x.Name)
            .Length(3, 50)
            .WithMessage("{PropertyName}  must be between {MinLength} and {MaxLength} characters.");

        RuleFor(x => x.Address)
            .Length(3, 50)
            .WithMessage("{PropertyName}  must be between {MinLength} and {MaxLength} characters.");

        RuleFor(x => x.Phone)
           .Length(11)
           .WithMessage("{PropertyName} length must be 11");
    }
}