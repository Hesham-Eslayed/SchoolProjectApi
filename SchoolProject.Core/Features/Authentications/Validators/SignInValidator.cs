using SchoolProject.Core.Features.Authentications.Commands.Models;

namespace SchoolProject.Core.Features.Authentications.Validators;

public class SignInValidator : AbstractValidator<SignInCommand>
{
	public SignInValidator()
	{
		ApplyValidationRules();
	}

	private void ApplyValidationRules()
	{
		RuleFor(x => x.UserName)
			.NotEmpty()
			.Length(3, 50)
			.WithMessage("{PropertyName} must not be null or empty");

		RuleFor(x => x.Password)
			.NotEmpty()
			.WithMessage("{PropertyName} must not be null or empty")
			.Length(3, 15)
			.WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters. You entered {TotalLength}.");

	}
}