using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.Features.Students.Queries.Handlers;
public class StudentHandler(IStudentService studentService)
    : IRequestHandler<GetStudentsQuery, IEnumerable<Student>>
{
    public async Task<IEnumerable<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        return await studentService.GetStudentsAsync();
    }
}
