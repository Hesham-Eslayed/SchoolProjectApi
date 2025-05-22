using SchoolProject.Core.Features.Departments.Queries.DTOs;

namespace SchoolProject.Core.Features.Departments.Queries.Models;

public record GetDepartmentQuery(int Id) : IRequest<Response<DepartmentDto>>;