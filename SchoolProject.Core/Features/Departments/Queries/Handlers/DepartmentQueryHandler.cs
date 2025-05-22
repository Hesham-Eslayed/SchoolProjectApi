using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Departments.Queries.DTOs;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Mapping.DepartmentMapping.QueryMapping;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Departments.Queries.Handlers;

public class DepartmentQueryHandler(
    IStringLocalizer<SharedResources> stringLocalizer,
    IDepartmentService departmentService,
    IStudentService studentService)
    : ResponseHandler(stringLocalizer),
    IRequestHandler<GetDepartmentQuery, Response<DepartmentDto>>
{
    public async Task<Response<DepartmentDto>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
    {
        var department = await departmentService.GetDepartmentByIdNoTrackingAsync(request.Id);

        if (department is null)
            return NotFound<DepartmentDto>();

        var query = studentService.GetStudentsByDepartmentIdQueryable(request.Id);

        var paginatedStudents = await query.ToStudentDtoQuery()
            .ToPaginatedListAsync(request.StudentPageNumber, request.StudenPageSize);

        var result = department.ToDepartmentDto(paginatedStudents);

        return Success(result);
    }
}