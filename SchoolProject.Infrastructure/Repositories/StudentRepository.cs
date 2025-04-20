

namespace SchoolProject.Infrastructure.Repositories;
public class StudentRepository(AppDbContext context) : IStudentRepository
{
    public async Task<IEnumerable<Student>> GetStudentsAsync() => await context.Students.ToListAsync();
}
