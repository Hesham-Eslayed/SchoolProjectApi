using SchoolProject.Infrastructure.InfarstructureBases;

namespace SchoolProject.Infrastructure.Interfaces;
public interface IStudentRepository : IGenericRepository<Student>
{
    Task<IEnumerable<Student>> GetStudentsAsync();
}
