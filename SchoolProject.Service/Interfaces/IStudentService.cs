namespace SchoolProject.Service.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetStudentsAsync();

    Task<Student?> GetStudentByIdAsync(int id);

    Task<Student?> AddAsync(Student student);

    Task<bool> IsNameExistsExcludeSelfAsync(int id, string name);

    Task<bool> IsNameExistAsync(string name);

    Task<bool> IsPhoneExistAsync(string phone);

    Task<bool> IsPhoneExistsExcludeSelfAsync(int id, string phone);

    Task<bool> UpdateAsync(Student student);
}