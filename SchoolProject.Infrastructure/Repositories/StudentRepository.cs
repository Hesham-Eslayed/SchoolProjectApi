

using SchoolProject.Infrastructure.InfarstructureBases;

namespace SchoolProject.Infrastructure.Repositories;
public class StudentRepository :
    GenericRepository<Student>,
    IStudentRepository
{
    private readonly DbSet<Student> _students;

    public StudentRepository(AppDbContext context) : base(context)
    {
        _students = context.Set<Student>();
    }

    public async Task<IEnumerable<Student>> GetStudentsAsync()
        => await GetTableNoTracking().Include(s => s.Department)
        .Include(s => s.Subjects).ToListAsync();
}
