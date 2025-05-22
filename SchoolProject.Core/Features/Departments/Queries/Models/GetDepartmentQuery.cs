using SchoolProject.Core.Features.Departments.Queries.DTOs;

namespace SchoolProject.Core.Features.Departments.Queries.Models;

public record GetDepartmentQuery(int Id, int StudentPageNumber = 1, int StudenPageSize = 10) : IRequest<Response<DepartmentDto>>;