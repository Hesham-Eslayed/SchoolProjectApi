namespace SchoolProject.Domain.Entities;

public class Subject
{

    public int SubID { get; set; }

    public required string SubjectName { get; set; }

    public int Period { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

    public virtual ICollection<Department> Departments { get; set; } = new HashSet<Department>();

    public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
}