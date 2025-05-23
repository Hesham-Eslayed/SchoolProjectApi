using SchoolProject.Domain.Common;

namespace SchoolProject.Domain.Entities;

public class Instructor : ILocalizeEntity
{
    public int InsId { get; set; }

    public required string NameEn { get; set; }

    public string? NameAr { get; set; }

    public string? Address { get; set; }

    public string? Position { get; set; }

    public int? SupervisorId { get; set; }

    public decimal? Salary { get; set; }

    public string? Image { get; set; }

    public int DID { get; set; }

    public virtual Department Department { get; set; } = null!;

    public Instructor? Supervisor { get; set; }

    public virtual IEnumerable<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

    public virtual IEnumerable<Subject> Subjects { get; set; } = new HashSet<Subject>();

}