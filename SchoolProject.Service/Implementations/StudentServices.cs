using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Enums;
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

    public async Task<bool> DeleteAsync(Student student) => await repo.DeleteAsync(student);

    public IQueryable<Student> GetPaginatedQueryable(StudentOrderingEnum order, string? search)
    {
        var query = repo.GetTableNoTracking().Include(x => x.Department).AsQueryable();

        if (!string.IsNullOrEmpty(search))
            query = query.Where(x => x.NameEn.Contains(search) || x.Department!.DNameEn.Contains(search));

        query = order == StudentOrderingEnum.DepartmentName ? query.OrderBy(x => x.Department!.DNameEn)
            : query.OrderBy(order.ToString());

        return query;
    }

    public async Task<Student?> GetStudentByIdAsync(int id) => await repo.GetByIdAsync(id);

    public async Task<Student?> GetStudentByIdWithIncludeAsync(int id) => await repo.GetTableNoTracking()
            .Include(x => x.Department)
            .Include(x => x.Subjects)
            .FirstOrDefaultAsync(x => x.StudID.Equals(id));

    public async Task<IEnumerable<Student>> GetStudentsAsync() => await repo.GetTableNoTracking()
        .Include(s => s.Department)
            .Include(s => s.Subjects).ToListAsync();
    public IQueryable<Student> GetStudentsByDepartmentIdQueryable(int id)
    {
        var query = repo.GetTableNoTracking().Where(x => x.DID.Equals(id)).AsQueryable();

        return query;
    }

    public async Task<bool> IsNameExistAsync(string name) => await repo.GetTableNoTracking()
        .AnyAsync(x => x.NameEn.Equals(name));

    public async Task<bool> IsNameExistsExcludeSelfAsync(int id, string name) => await repo.GetTableNoTracking()
        .AnyAsync(x => x.NameEn.Equals(name) && !x.StudID.Equals(id));

    public async Task<bool> IsPhoneExistAsync(string phone) => await repo.GetTableNoTracking()
        .AnyAsync(x => x.Phone!.Equals(phone));

    public async Task<bool> IsPhoneExistsExcludeSelfAsync(int id, string phone) => await repo.GetTableNoTracking()
        .AnyAsync(x => x.Phone!.Equals(phone) && !x.StudID.Equals(id));

    public async Task<bool> UpdateAsync(Student student) => await repo.UpdateAsync(student);
}