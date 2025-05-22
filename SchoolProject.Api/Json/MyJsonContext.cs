using System.Text.Json.Serialization;
using SchoolProject.Core.Features.Departments.Queries.DTOs;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Api.Json;

#region Student

[JsonSerializable(typeof(GetStudentDto))]
[JsonSerializable(typeof(GetStudentsDto))]
[JsonSerializable(typeof(AddStudentCommand))]
[JsonSerializable(typeof(EditStudentCommand))]
[JsonSerializable(typeof(Response<IEnumerable<GetStudentsDto>>))]
[JsonSerializable(typeof(Response<GetStudentDto>))]
[JsonSerializable(typeof(Response<Unit>))]
[JsonSerializable(typeof(DeleteStudentCommand))]
[JsonSerializable(typeof(GetStudentPaginatedListQuery))]
[JsonSerializable(typeof(PaginatedResult<GetStudentPaginatedListResponse>))]

#endregion Student



#region Department
[JsonSerializable(typeof(GetDepartmentQuery))]
[JsonSerializable(typeof(DepartmentDto))]
[JsonSerializable(typeof(Response<DepartmentDto>))]
#endregion


public partial class MyJsonContext : JsonSerializerContext
{
}