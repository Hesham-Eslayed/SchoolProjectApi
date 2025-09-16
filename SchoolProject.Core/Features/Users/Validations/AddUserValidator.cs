using SchoolProject.Core.Features.Users.Commands.Models;

namespace SchoolProject.Core.Features.Users.Validations;

public class AddUserValidator : AbstractValidator<AddUserCommand>
{

	public AddUserValidator()
	{
		ApplyValidationRules();
	}

	private void ApplyValidationRules()
	{
		RuleFor(x => x.UserName)
			.NotEmpty()
			.Length(3, 50)
			.WithMessage("{PropertyName} must not be null or empty");

		RuleFor(x => x.Email)
			.NotEmpty()
			.EmailAddress()
			.WithMessage("{PropertyName} must be a valid email address");

		RuleFor(x => x.Address)
			.MaximumLength(100)
			.WithMessage("{PropertyName} must not exceed 100 characters");

		RuleFor(x => x.Password)
			.NotEmpty()
			.WithMessage("{PropertyName} must not be null or empty")
			.Length(3, 15)
			.WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters. You entered {TotalLength}.");

		RuleFor(x => x.ConfirmPassword)
			.Matches(x => x.Password)
			.WithMessage("{PropertyName} must not match password");

	}
}