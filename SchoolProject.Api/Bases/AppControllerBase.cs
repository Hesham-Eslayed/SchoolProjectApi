using System.Net;

namespace SchoolProject.Api.Bases;

[ApiController]
[Produces("application/json")]
public class AppControllerBase : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();


    public ObjectResult NewResult<T>(Response<T> response) => response.StatusCode switch
    {
        HttpStatusCode.OK => new OkObjectResult(response),
        HttpStatusCode.Created => new CreatedResult(string.Empty, response),
        HttpStatusCode.Unauthorized => new UnauthorizedObjectResult(response),
        HttpStatusCode.BadRequest => new BadRequestObjectResult(response),
        HttpStatusCode.NotFound => new NotFoundObjectResult(response),
        HttpStatusCode.Accepted => new AcceptedResult(string.Empty, response),
        HttpStatusCode.UnprocessableEntity => new UnprocessableEntityObjectResult(response),
        _ => new BadRequestObjectResult(response),
    };
}