namespace SchoolProject.Domain.Entities;

public class DepartmentsSubjects
{
    public int DID { get; set; }

    public int SubID { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}