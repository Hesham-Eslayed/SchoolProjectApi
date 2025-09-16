using System.Text.Json.Serialization;
using SchoolProject.Core.Features.Authentications.Commands.Models;
using SchoolProject.Core.Features.Departments.Queries.DTOs;
using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Features.Users.Queries.Models;
using SchoolProject.Core.Features.Users.Queries.Responses;
using SchoolProject.Core.Wrappers;
using SchoolProject.Domain.Entities;

namespace SchoolProject.Api.Json;

#region Student

[JsonSerializable(typeof(GetStudentDto))]
[JsonSerializable(typeof(GetStudentsDto))]
[JsonSerializable(typeof(AddStudentCommand))]
[JsonSerializable(typeof(EditStudentCommand))]
[JsonSerializable(typeof(Response<IEnumerable<GetStudentsDto>>))]
[JsonSerializable(typeof(Response<GetStudentDto>))]
[JsonSerializable(typeof(Response<Student>))]
[JsonSerializable(typeof(Response<Unit>))]
[JsonSerializable(typeof(Response<string>))]
[JsonSerializable(typeof(DeleteStudentCommand))]
[JsonSerializable(typeof(GetStudentPaginatedListQuery))]
[JsonSerializable(typeof(PaginatedResult<GetStudentPaginatedListResponse>))]
[JsonSerializable(typeof(ValidationProblemDetails))]

#endregion Student

#region Department

[JsonSerializable(typeof(GetDepartmentQuery))]
[JsonSerializable(typeof(DepartmentDto))]
[JsonSerializable(typeof(Response<DepartmentDto>))]

#endregion Department

#region Users

[JsonSerializable(typeof(AddUserCommand))]
[JsonSerializable(typeof(GetUserListQuery))]
[JsonSerializable(typeof(PaginatedResult<GetUserResponse>))]
[JsonSerializable(typeof(Response<GetUserByIdResponse>))]
[JsonSerializable(typeof(GetUserByIdQuery))]
[JsonSerializable(typeof(UpdateUserCommand))]
[JsonSerializable(typeof(DeleteUserCommand))]
[JsonSerializable(typeof(ChangeUserPasswordCommand))]

#endregion

#region Authentication

[JsonSerializable(typeof(SignInCommand))]

#endregion

public partial class MyJsonContext : JsonSerializerContext
{
}