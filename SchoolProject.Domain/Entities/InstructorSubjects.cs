namespace SchoolProject.Domain.Entities;

public class InstructorSubjects
{
	public int InsId { get; set; }

	public int SubID { get; set; }

	public virtual Instructor Instructor { get; set; } = null!;

	public virtual Subject Subject { get; set; } = null!;
}