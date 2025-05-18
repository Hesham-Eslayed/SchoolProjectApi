namespace SchoolProject.Service.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetStudentsAsync();

    Task<Student?> GetStudentByIdAsync(int id);

    Task<Student?> AddAsync(Student student);

    Task<bool> IsNameExistsAsync(string name);
}