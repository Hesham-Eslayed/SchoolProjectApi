namespace SchoolProject.Domain.Entities;

public class StudentSubject
{
    [Key]
    public int StudSubID { get; set; }
    public int StudID { get; set; }
    public int SubID { get; set; }

    [ForeignKey(nameof(StudID))]
    public virtual Student Student { get; set; } = null!;

    [ForeignKey(nameof(SubID))]
    public virtual Subject Subject { get; set; } = null!;

}

