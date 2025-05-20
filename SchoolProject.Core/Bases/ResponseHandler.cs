using Microsoft.Extensions.Localization;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Bases;

public class ResponseHandler(IStringLocalizer<SharedResources> stringLocalizer)
{

    public Response<T> Deleted<T>() => new()
    {
        StatusCode = System.Net.HttpStatusCode.NoContent,
        Succeeded = true,
        Message = stringLocalizer[SharedResourcesKeys.Deleted]
    };

    public Response<T> NoContent<T>(string? message = null) => new()
    {
        StatusCode = System.Net.HttpStatusCode.NoContent,
        Succeeded = true,
        Message = message ?? stringLocalizer[SharedResourcesKeys.Updated]
    };

    public Response<T> Success<T>(T entity, string? message = null, object? Meta = null) => new()
    {
        Data = entity,
        StatusCode = System.Net.HttpStatusCode.OK,
        Succeeded = true,
        Message = message ?? stringLocalizer[SharedResourcesKeys.Success],
        Meta = Meta
    };

    public Response<T> Unauthorized<T>() => new()
    {
        StatusCode = System.Net.HttpStatusCode.Unauthorized,
        Succeeded = true,
        Message = stringLocalizer[SharedResourcesKeys.UnAuthorized]
    };

    public Response<T> BadRequest<T>(string? Message = null) => new()
    {
        StatusCode = System.Net.HttpStatusCode.BadRequest,
        Succeeded = false,
        Message = Message ?? stringLocalizer[SharedResourcesKeys.BadRequest]
    };

    public Response<T> UnprocessableEntity<T>(string? Message = null) => new()
    {
        StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
        Succeeded = false,
        Message = Message ?? stringLocalizer[SharedResourcesKeys.UnprocessableEntity]
    };

    public Response<T> NotFound<T>(string? message = null) => new()
    {
        StatusCode = System.Net.HttpStatusCode.NotFound,
        Succeeded = false,
        Message = message ?? stringLocalizer[SharedResourcesKeys.NotFound]
    };

    public Response<T> Created<T>(T? entity, object? Meta = null) => new()
    {
        Data = entity,
        StatusCode = System.Net.HttpStatusCode.Created,
        Succeeded = true,
        Message = stringLocalizer[SharedResourcesKeys.Created],
        Meta = Meta
    };
}