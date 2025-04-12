namespace SchoolProject.Domain.Entities;

public class Department
{

    [Key]
    public int DID { get; set; }
    [StringLength(500)]
    public required string DName { get; set; }
    public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    public virtual ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
}

