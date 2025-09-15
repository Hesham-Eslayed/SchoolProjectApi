using System.Net;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Bases;

public class ResponseHandler(IStringLocalizer<SharedResources> stringLocalizer)
{

	public Response<T> Deleted<T>() => new()
	{
		StatusCode = HttpStatusCode.NoContent,
		Succeeded = true,
		Message = stringLocalizer[SharedResourcesKeys.Deleted]
	};

	public Response<T> NoContent<T>(string? message = null) => new()
	{
		StatusCode = HttpStatusCode.NoContent,
		Succeeded = true,
		Message = message ?? stringLocalizer[SharedResourcesKeys.Updated]
	};

	public Response<T> Success<T>(T? entity, string? message = null, object? meta = null) => new()
	{
		Data = entity,
		StatusCode = HttpStatusCode.OK,
		Succeeded = true,
		Message = message ?? stringLocalizer[SharedResourcesKeys.Success],
		Meta = meta
	};

	public Response<T> Unauthorized<T>() => new()
	{
		StatusCode = HttpStatusCode.Unauthorized,
		Succeeded = true,
		Message = stringLocalizer[SharedResourcesKeys.UnAuthorized]
	};

	public Response<T> BadRequest<T>(string? message = null) => new()
	{
		StatusCode = HttpStatusCode.BadRequest,
		Succeeded = false,
		Message = message ?? stringLocalizer[SharedResourcesKeys.BadRequest]
	};

	public Response<T> UnprocessableEntity<T>(string? message = null) => new()
	{
		StatusCode = HttpStatusCode.UnprocessableEntity,
		Succeeded = false,
		Message = message ?? stringLocalizer[SharedResourcesKeys.UnprocessableEntity]
	};

	public Response<T> NotFound<T>(string? message = null) => new()
	{
		StatusCode = HttpStatusCode.NotFound,
		Succeeded = false,
		Message = message ?? stringLocalizer[SharedResourcesKeys.NotFound]
	};

	public Response<T> Created<T>(T? entity, object? meta = null) => new()
	{
		Data = entity,
		StatusCode = HttpStatusCode.Created,
		Succeeded = true,
		Message = stringLocalizer[SharedResourcesKeys.Created],
		Meta = meta
	};
}