using SchoolProject.Domain.Common;

namespace SchoolProject.Domain.Entities;

public class Student : LocalizeEntity
{
    [Key]
    public int StudID { get; set; }

    [StringLength(200)]
    public required string NameEn { get; set; }

    [StringLength(200)]
    public string? NameAr { get; set; }

    [StringLength(500)]
    public string? Address { get; set; }

    [StringLength(500)]
    public string? Phone { get; set; }

    public int DID { get; set; }

    public virtual Department Department { get; set; } = null!;

    public ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();

    public ICollection<StudentsSubjects> StudentSubjects { get; set; } = new HashSet<StudentsSubjects>();
}