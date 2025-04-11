using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Domain.Entities;

public class DepartmentSubject
{
    [Key]
    public int DeptSubID { get; set; }
    public int DID { get; set; }
    public int SubID { get; set; }

    [ForeignKey("DID")]
    public virtual Department Department { get; set; } = null!;

    [ForeignKey("SubID")]
    public virtual Subject Subject { get; set; } = null!;
}

