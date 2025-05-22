using SchoolProject.Domain.Common;

namespace SchoolProject.Domain.Entities;

public class Subject : LocalizeEntity
{

    public int SubID { get; set; }

    public required string SubjectNameEn { get; set; }

    public string? SubjectNameAr { get; set; }

    public int Period { get; set; }

    public virtual IEnumerable<Student> Students { get; set; } = new HashSet<Student>();

    public virtual IEnumerable<Department> Departments { get; set; } = new HashSet<Department>();

    public virtual IEnumerable<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
}