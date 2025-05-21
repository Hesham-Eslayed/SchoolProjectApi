using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolProject.Infrastructure.Config;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasMany(x => x.Students)
            .WithMany(x => x.Subjects)
            .UsingEntity<StudentsSubjects>(
            j =>
            {
                j.HasKey(x => new { x.StudID, x.SubID });

                j.ToTable($"{nameof(Subject.Students)}{nameof(Student.Subjects)}");

                j.HasOne(ss => ss.Student)
                 .WithMany()
                 .HasForeignKey(ss => ss.StudID);

                j.HasOne(ss => ss.Subject)
                 .WithMany()
                 .HasForeignKey(ss => ss.SubID);
            }
            );


        builder.HasMany(x => x.Departments)
           .WithMany(x => x.Subjects)
           .UsingEntity<DepartmentsSubjects>(
            j =>
            {
                j.HasKey(x => new { x.DID, x.SubID });

                j.ToTable($"{nameof(Subject.Departments)}{nameof(Department.Subjects)}");

                j.HasOne(ds => ds.Department)
                 .WithMany()
                 .HasForeignKey(ds => ds.DID);


                j.HasOne(ds => ds.Subject)
                 .WithMany()
                 .HasForeignKey(ds => ds.SubID);

            }
            );


        builder.HasMany(x => x.Instructors)
          .WithMany(x => x.Subjects)
          .UsingEntity<InstructorsSubjects>(
           j =>
           {
               j.HasKey(x => new { x.InsId, x.SubID });

               j.ToTable($"{nameof(Subject.Instructors)}{nameof(Instructor.Subjects)}");

               j.HasOne(inss => inss.Instructor)
                .WithMany()
                .HasForeignKey(inss => inss.InsId);


               j.HasOne(inss => inss.Subject)
                .WithMany()
                .HasForeignKey(inss => inss.SubID);


           }
           );

    }
}