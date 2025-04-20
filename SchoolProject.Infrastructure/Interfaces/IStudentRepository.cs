namespace SchoolProject.Infrastructure.Interfaces;
public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetStudentsAsync();
}
