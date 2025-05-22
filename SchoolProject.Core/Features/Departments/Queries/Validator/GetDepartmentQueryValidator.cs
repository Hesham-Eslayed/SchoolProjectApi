using SchoolProject.Core.Features.Departments.Queries.Models;

namespace SchoolProject.Core.Features.Departments.Queries.Validator;
public class GetDepartmentQueryValidator : AbstractValidator<GetDepartmentQuery>
{
    public GetDepartmentQueryValidator()
    {
        RuleFor(x => x.StudentPageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} should be greater than or equal {ComparisonValue}");

        RuleFor(x => x.StudenPageSize)
           .GreaterThanOrEqualTo(1)
            .WithMessage("{PropertyName} should be greater than or equal {ComparisonValue}");
    }
}
