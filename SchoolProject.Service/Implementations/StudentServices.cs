using Microsoft.EntityFrameworkCore;

using SchoolProject.Domain.Interfaces.Persistence;

namespace SchoolProject.Service.Implementations;

public class StudentServices(IStudentRepository repo) : IStudentService
{
    public async Task<Student?> AddAsync(Student student)
    {
        await repo.AddAsync(student);
        await repo.SaveChangesAsync();

        return student;
    }



    public async Task<Student?> GetStudentByIdAsync(int id) => await repo.GetTableNoTracking()
            .Include(x => x.Department)
            .Include(x => x.Subjects)
            .FirstOrDefaultAsync(x => x.StudID == id);

    public async Task<IEnumerable<Student>> GetStudentsAsync() => await repo.GetTableNoTracking()
        .Include(s => s.Department)
            .Include(s => s.Subjects).ToListAsync();

    public async Task<bool> IsNameExistAsync(string name) => await repo.GetTableNoTracking()
        .AnyAsync(x => x.Name.Equals(name));

    public async Task<bool> IsNameExistsExcludeSelfAsync(int id, string name) => await repo.GetTableNoTracking()
        .AnyAsync(x => x.Name.Equals(name) && !x.StudID.Equals(id));

    public async Task<bool> IsPhoneExistAsync(string phone) => await repo.GetTableNoTracking()
        .AnyAsync(x => x.Phone.Equals(phone));

    public async Task<bool> IsPhoneExistsExcludeSelfAsync(int id, string phone) => await repo.GetTableNoTracking()
        .AnyAsync(x => x.Phone.Equals(phone) && !x.StudID.Equals(id));

    public async Task<bool> UpdateAsync(Student student) => await repo.UpdateAsync(student);
}