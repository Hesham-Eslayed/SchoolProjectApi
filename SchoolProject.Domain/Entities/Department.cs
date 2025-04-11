using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Domain.Entities;

public class Department
{

    [Key]
    public int DID { get; set; }
    [StringLength(500)]
    public required string DName { get; set; }
    public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
    public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; } = new HashSet<DepartmentSubject>();
}

