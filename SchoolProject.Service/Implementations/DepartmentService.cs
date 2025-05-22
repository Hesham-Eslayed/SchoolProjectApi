using Microsoft.EntityFrameworkCore;
using SchoolProject.Domain.Interfaces.Persistence;

namespace SchoolProject.Service.Implementations;

public class DepartmentService(IDepartmentRepository departmentRepository) : IDepartmentService
{
    public async Task<Department?> GetDepartmentByIdNoTrackingAsync(int id)
    {
        return await departmentRepository.GetTableNoTracking()
            .Include(x => x.Subjects)
            .Include(x => x.Manager)
            .Include(x => x.Students)
            .Include(x => x.Instructors)
            .FirstOrDefaultAsync(x => x.DID.Equals(id));
    }
}