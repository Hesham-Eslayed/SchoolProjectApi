namespace SchoolProject.Core.Features.Students.Shared;

public class BaseStudentCommand
{
    public string? NameEn { get; set; }

    public string? NameAr { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public int? DepartmentId { get; set; }
}