using Microsoft.EntityFrameworkCore;

using SchoolProject.Domain.Interfaces.Persistence;

namespace SchoolProject.Service.Implementations;

public class StudentServices(IStudentRepository repo) : IStudentService
{
    public async Task<Student?> AddAsync(Student student)
    {
        var studentResult = await repo.GetTableNoTracking().Where(x => x.Phone.Equals(student.Phone))
            .FirstOrDefaultAsync();
        if (studentResult is not null)
            return null;

        await repo.AddAsync(student);
        await repo.SaveChangesAsync();

        return student;
    }

    public async Task<Student?> GetStudentByIdAsync(int id) => await repo.GetTableNoTracking()
            .Include(x => x.Department)
            .Include(x => x.Subjects)
            .FirstOrDefaultAsync(x => x.StudID == id);

    public async Task<IEnumerable<Student>> GetStudentsAsync() => await repo.GetStudentsAsync();

    public async Task<bool> IsNameExistsAsync(string name) => await repo.IsNameExistsAsync(name);
}