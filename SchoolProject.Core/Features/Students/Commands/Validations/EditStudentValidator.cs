using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Shared;

namespace SchoolProject.Core.Features.Students.Commands.Validations;

public class EditStudentValidator : AbstractValidator<EditStudentCommand>
{
    private readonly IStudentService _studentService;

    public EditStudentValidator(IStudentService studentService)
    {
        Include(new BaseStudentCommandValidator());
        this._studentService = studentService;
        ApplyCustomValidation();
    }

    private void ApplyCustomValidation()
    {
        RuleFor(x => x.Name)
                   .MustAsync(async (model, key, CancellationToken)
                       => !await _studentService.IsNameExistsExcludeSelfAsync(model.Id, key!))
                       .WithMessage("{PropertyValue} is already exists");

        RuleFor(x => x.Phone)
           .MustAsync(async (model, key, CancellationToken)
           => key is null || !await _studentService.IsPhoneExistsExcludeSelfAsync(model.Id, key))
           .WithMessage("{PropertyValue} already exists");

    }
}