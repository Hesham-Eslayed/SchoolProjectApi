using SchoolProject.Domain.Common;

namespace SchoolProject.Domain.Entities;

public class Instructor : LocalizeEntity
{
    [Key]
    public int InsId { get; set; }

    public string? NameEn { get; set; }

    public string? NameAr { get; set; }

    public string? Address { get; set; }

    public string? Position { get; set; }

    public int? SupervisorId { get; set; }

    public decimal? Salary { get; set; }

    public string? Image { get; set; }

    public int DID { get; set; }

    public Department? Department { get; set; }

    public Instructor? Supervisor { get; set; }

    public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();

    public virtual ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
}