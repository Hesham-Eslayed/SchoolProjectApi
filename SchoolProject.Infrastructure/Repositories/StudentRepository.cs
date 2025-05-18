using SchoolProject.Domain.Interfaces.Persistence;
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


}