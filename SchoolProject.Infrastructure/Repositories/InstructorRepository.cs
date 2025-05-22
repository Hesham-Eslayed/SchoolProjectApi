using SchoolProject.Domain.Interfaces.Persistence;
using SchoolProject.Infrastructure.InfarstructureBases;

namespace SchoolProject.Infrastructure.Repositories;

public class InstructorRepository(AppDbContext context)
    : GenericRepository<Instructor>(context),
    IInstructorRepository
{
    private readonly DbSet<Instructor> _instructors = context.Instructors;
}