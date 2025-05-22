namespace SchoolProject.Service.Interfaces;

public interface IDepartmentService
{
    Task<Department?> GetDepartmentByIdNoTrackingAsync(int id);
}