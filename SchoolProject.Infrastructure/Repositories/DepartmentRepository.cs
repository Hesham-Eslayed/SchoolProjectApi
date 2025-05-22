using SchoolProject.Domain.Interfaces.Persistence;
using SchoolProject.Infrastructure.InfarstructureBases;

namespace SchoolProject.Infrastructure.Repositories;

public class DepartmentRepository(AppDbContext context)
    : GenericRepository<Department>(context),
    IDepartmentRepository
{
    private readonly DbSet<Department> _departments = context.Departments;

}