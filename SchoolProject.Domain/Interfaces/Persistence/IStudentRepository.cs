using SchoolProject.Domain.Entities;

namespace SchoolProject.Domain.Interfaces.Persistence;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<IEnumerable<Student>> GetStudentsAsync();
}