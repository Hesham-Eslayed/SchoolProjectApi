namespace SchoolProject.Core.Features.Students.Queries.Models;
public class GetStudentByIdQuery(int id) : IRequest<Response<GetStudentDto>>
{
    public int Id { get; } = id;
}
