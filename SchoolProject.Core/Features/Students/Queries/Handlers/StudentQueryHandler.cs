using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.Features.Students.Queries.Handlers;

public class StudentQueryHandler(IStudentService studentService)
    : ResponseHandler,
    IRequestHandler<GetStudentsQuery, Response<IEnumerable<GetStudentsDto>>>,
    IRequestHandler<GetStudentByIdQuery, Response<GetStudentDto>>,
    IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
{
    public async Task<Response<GetStudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var student = await studentService.GetStudentByIdWithIncludeAsync(request.Id);
        return student is null ? NotFound<GetStudentDto>() : Success(student.ToDto(), "Found");
    }

    public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request,
                                                                         CancellationToken cancellationToken)
    {
        var query = studentService.GetPaginatedQueryable(request.OrderBy, request.Search);

        var paginatedResult = await query
            .Select(x => new GetStudentPaginatedListResponse()
            {
                Address = x.Address,
                DepartmentName = x.Department!.DName,
                Name = x.Name,
                StudID = x.StudID
            })
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);

        return paginatedResult;
    }

    async Task<Response<IEnumerable<GetStudentsDto>>> IRequestHandler<GetStudentsQuery,
        Response<IEnumerable<GetStudentsDto>>>.Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var studentList = await studentService.GetStudentsAsync();
        return Success(studentList.ToDtoList());
    }

}