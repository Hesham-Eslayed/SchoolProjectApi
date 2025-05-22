using SchoolProject.Domain.Common;

namespace SchoolProject.Domain.Entities;

public class Department : LocalizeEntity
{

    public int DID { get; set; }

    public required string DNameEn { get; set; }

    public string? DNameAr { get; set; }

    public int? ManagerId { get; set; }

    public virtual Instructor? Manager { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
}