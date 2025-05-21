namespace SchoolProject.Domain.Entities;

public class StudentsSubjects
{

    public int StudID { get; set; }

    public int SubID { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;

}