using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolProject.Infrastructure.Config;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasOne(x => x.Supervisor)
            .WithMany(x => x.Instructors)
            .HasForeignKey(x => x.SupervisorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Department)
           .WithMany(x => x.Instructors)
           .HasForeignKey(x => x.DID)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Salary)
            .HasPrecision(18, 2);

    }
}