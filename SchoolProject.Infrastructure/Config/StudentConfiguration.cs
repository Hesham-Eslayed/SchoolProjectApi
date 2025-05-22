using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolProject.Infrastructure.Config;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.StudID);

        #region Properties

        builder.Property(x => x.NameEn)
            .HasMaxLength(100);

        builder.Property(x => x.NameAr)
            .HasMaxLength(100);

        builder.Property(x => x.Address)
            .HasMaxLength(200);

        builder.Property(x => x.Phone)
            .HasMaxLength(15);


        #endregion Properties
    }
}