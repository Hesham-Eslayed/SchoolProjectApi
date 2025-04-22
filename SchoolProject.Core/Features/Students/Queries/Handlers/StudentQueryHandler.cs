

namespace SchoolProject.Core.Features.Students.Queries.Handlers;
public class StudentQueryHandler(IStudentService studentService)
    : ResponseHandler,
    IRequestHandler<GetStudentsQuery, Response<IEnumerable<GetStudentsDto>>>,
    IRequestHandler<GetStudentByIdQuery, Response<GetStudentDto>>
{
    public async Task<Response<GetStudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await studentService.GetStudentByIdAsync(request.Id);
        return student is null ? NotFound<GetStudentDto>() : Success(student.ToDto(), "Found");
    }

    async Task<Response<IEnumerable<GetStudentsDto>>> IRequestHandler<GetStudentsQuery,
        Response<IEnumerable<GetStudentsDto>>>.Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var studentList = await studentService.GetStudentsAsync();
        return Success(studentList.ToDtoList());
    }
}
