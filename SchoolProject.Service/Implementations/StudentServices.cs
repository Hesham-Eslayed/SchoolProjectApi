

using Microsoft.EntityFrameworkCore;

namespace SchoolProject.Service.Implementations;
public class StudentServices(IStudentRepository repo) : IStudentService
{
    public async Task<Student?> GetStudentByIdAsync(int id) =>
            await repo.GetTableNoTracking()
            .Include(x => x.Department)
            .Include(x => x.Subjects)
            .FirstOrDefaultAsync(x => x.StudID == id);

    public async Task<IEnumerable<Student>> GetStudentsAsync() => await repo.GetStudentsAsync();
}
