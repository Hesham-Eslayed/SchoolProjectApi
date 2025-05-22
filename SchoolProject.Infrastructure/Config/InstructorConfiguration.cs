using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolProject.Infrastructure.Config;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {

        builder.HasKey(x => x.InsId);

        #region Relations

        builder.HasOne(x => x.Supervisor)
          .WithMany(x => x.Instructors)
          .HasForeignKey(x => x.SupervisorId)
          .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Department)
           .WithMany(x => x.Instructors)
           .HasForeignKey(x => x.DID)
           .OnDelete(DeleteBehavior.Restrict);


        #endregion Relations

        #region Properties

        builder.Property(x => x.Address)
            .HasMaxLength(200);

        builder.Property(x => x.NameEn)
           .HasMaxLength(100);

        builder.Property(x => x.NameAr)
            .HasMaxLength(100);

        builder.Property(x => x.Position)
           .HasMaxLength(200);

        builder.Property(x => x.Image)
           .HasMaxLength(500);

        builder.Property(x => x.Salary)
            .HasPrecision(18, 2);

        #endregion Properties

    }
}