

namespace SchoolProject.Service.Implementations;
public class StudentServices(IStudentRepository repo) : IStudentService
{
    public async Task<IEnumerable<Student>> GetStudentsAsync() => await repo.GetStudentsAsync();
}
