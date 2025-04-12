namespace SchoolProject.Domain.Entities;

public class Subject
{

    [Key]
    public int SubID { get; set; }
    [StringLength(500)]
    public required string SubjectName { get; set; }
    public DateTime Period { get; set; }
    public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    public virtual ICollection<Department> Departments { get; set; } = new HashSet<Department>();
}

