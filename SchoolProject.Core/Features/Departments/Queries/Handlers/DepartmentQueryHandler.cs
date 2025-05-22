using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Departments.Queries.DTOs;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Mapping.DepartmentMapping.QueryMapping;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Departments.Queries.Handlers;

public class DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IDepartmentService departmentService)
    : ResponseHandler(stringLocalizer),
    IRequestHandler<GetDepartmentQuery, Response<DepartmentDto>>
{
    public async Task<Response<DepartmentDto>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
    {
        var department = await departmentService.GetDepartmentByIdNoTrackingAsync(request.Id);

        if (department is null)
            return NotFound<DepartmentDto>();

        var result = department.ToDepartmentDto();

        return Success(result);
    }
}