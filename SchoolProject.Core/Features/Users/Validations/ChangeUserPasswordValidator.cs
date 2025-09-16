using SchoolProject.Core.Features.Users.Commands.Models;

namespace SchoolProject.Core.Features.Users.Validations;

public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
{

	public ChangeUserPasswordValidator()
	{
		ApplyValidationRules();
	}

	private void ApplyValidationRules()
	{

		RuleFor(x => x.CurrentPassword)
			.NotEmpty()
			.WithMessage("{PropertyName} must not be null or empty")
			.Length(3, 15)
			.WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters. You entered {TotalLength}.");

		RuleFor(x => x.NewPassword)
			.NotEmpty()
			.WithMessage("{PropertyName} must not be null or empty")
			.Length(3, 15)
			.WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters. You entered {TotalLength}.");

		RuleFor(x => x.ConfirmPassword)
			.Matches(x => x.NewPassword)
			.WithMessage("{PropertyName} must not match password");

		;
	}
}