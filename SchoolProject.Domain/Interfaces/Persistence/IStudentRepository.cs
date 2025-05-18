using SchoolProject.Domain.Entities;

namespace SchoolProject.Domain.Interfaces.Persistence;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<IEnumerable<Student>> GetStudentsAsync();

    Task<bool> IsNameExistsAsync(string name);

}