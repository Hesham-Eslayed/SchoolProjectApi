using SchoolProject.Domain.Common;

namespace SchoolProject.Domain.Entities;

public class Student : LocalizeEntity
{
	public int StudID { get; set; }

	public required string NameEn { get; set; }

	public string? NameAr { get; set; }

	public string? Address { get; set; }

	public string? Phone { get; set; }

	public int DID { get; set; }

	public virtual Department Department { get; set; } = null!;

	public IEnumerable<Subject> Subjects { get; set; } = new HashSet<Subject>();

	public IEnumerable<StudentsSubjects> StudentSubjects { get; set; } = new HashSet<StudentsSubjects>();
}