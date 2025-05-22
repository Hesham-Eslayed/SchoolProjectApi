using SchoolProject.Domain.Enums;

namespace SchoolProject.Service.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetStudentsAsync();

    Task<Student?> GetStudentByIdWithIncludeAsync(int id);

    Task<Student?> GetStudentByIdAsync(int id);

    Task<Student?> AddAsync(Student student);

    Task<bool> IsNameExistsExcludeSelfAsync(int id, string name);

    Task<bool> IsNameExistAsync(string name);

    Task<bool> IsPhoneExistAsync(string phone);

    Task<bool> IsPhoneExistsExcludeSelfAsync(int id, string phone);

    Task<bool> UpdateAsync(Student student);

    Task<bool> DeleteAsync(Student student);

    IQueryable<Student> GetPaginatedQueryable(StudentOrderingEnum order, string? search);
    IQueryable<Student> GetStudentsByDepartmentIdQueryable(int id);
}