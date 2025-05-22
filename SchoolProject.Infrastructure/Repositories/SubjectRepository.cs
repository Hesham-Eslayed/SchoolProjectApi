using SchoolProject.Domain.Interfaces.Persistence;
using SchoolProject.Infrastructure.InfarstructureBases;

namespace SchoolProject.Infrastructure.Repositories;

public class SubjectRepository(AppDbContext context)
    : GenericRepository<Subject>(context),
    ISubjectRepository
{
    private readonly DbSet<Subject> _subjects = context.Subjects;
}