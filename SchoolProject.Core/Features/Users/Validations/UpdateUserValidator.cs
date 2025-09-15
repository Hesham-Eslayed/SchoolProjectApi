using SchoolProject.Core.Features.Users.Commands.Models;

namespace SchoolProject.Core.Features.Users.Validations;

public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{

	public UpdateUserValidator()
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

	}
}