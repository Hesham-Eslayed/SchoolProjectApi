namespace SchoolProject.Core.Features.Students.Queries.Models;
public record GetStudentsQuery : IRequest<Response<IEnumerable<GetStudentsDto>>>;
