using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Domain.Entities;

public class Subject
{

    [Key]
    public int SubID { get; set; }
    [StringLength(500)]
    public required string SubjectName { get; set; }
    public DateTime Period { get; set; }
    public virtual ICollection<StudentSubject> StudentsSubjects { get; set; } = new HashSet<StudentSubject>();
    public virtual ICollection<DepartmentSubject> DepartmentsSubjects { get; set; } = new HashSet<DepartmentSubject>();
}

