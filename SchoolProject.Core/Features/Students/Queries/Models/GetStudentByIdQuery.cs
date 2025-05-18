namespace SchoolProject.Core.Features.Students.Queries.Models;
public record GetStudentByIdQuery(int Id) : IRequest<Response<GetStudentDto>>;
