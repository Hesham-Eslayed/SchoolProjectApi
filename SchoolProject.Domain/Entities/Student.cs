using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Domain.Entities;
public class Student
{
    [Key]
    public int StudID { get; set; }
    [StringLength(200)]
    public required string Name { get; set; }
    [StringLength(500)]
    public required string Address { get; set; }
    [StringLength(500)]
    public required string Phone { get; set; }
    public int? DID { get; set; }

    [ForeignKey(nameof(DID))]
    public virtual Department? Department { get; set; }
}
