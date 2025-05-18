namespace SchoolProject.Core.Bases;

public class ResponseHandler
{

    public Response<T> Deleted<T>() => new()
    {
        StatusCode = System.Net.HttpStatusCode.OK,
        Succeeded = true,
        Message = "Deleted Successfully"
    };

    public Response<T> NoContent<T>(string? message = null) => new()
    {
        StatusCode = System.Net.HttpStatusCode.NoContent,
        Succeeded = true,
        Message = message ?? "Deleted Successfully"
    };

    public Response<T> Success<T>(T entity, string? message = null, object? Meta = null) => new()
    {
        Data = entity,
        StatusCode = System.Net.HttpStatusCode.OK,
        Succeeded = true,
        Message = message ?? "Found Successfully",
        Meta = Meta
    };

    public Response<T> Unauthorized<T>() => new()
    {
        StatusCode = System.Net.HttpStatusCode.Unauthorized,
        Succeeded = true,
        Message = "UnAuthorized"
    };

    public Response<T> BadRequest<T>(string? Message = null) => new()
    {
        StatusCode = System.Net.HttpStatusCode.BadRequest,
        Succeeded = false,
        Message = Message ?? "Bad Request"
    };

    public Response<T> NotFound<T>(string? message = null) => new()
    {
        StatusCode = System.Net.HttpStatusCode.NotFound,
        Succeeded = false,
        Message = message ?? "Not Found"
    };

    public Response<T> Created<T>(T? entity, object? Meta = null) => new()
    {
        Data = entity,
        StatusCode = System.Net.HttpStatusCode.Created,
        Succeeded = true,
        Message = "Created",
        Meta = Meta
    };
}