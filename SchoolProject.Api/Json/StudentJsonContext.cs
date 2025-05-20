using System.Text.Json.Serialization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Api.Json;

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
public partial class MyJsonContext : JsonSerializerContext
{
}