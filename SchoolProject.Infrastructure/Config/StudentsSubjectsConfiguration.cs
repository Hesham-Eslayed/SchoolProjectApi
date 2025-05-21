using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolProject.Infrastructure.Config;

public class StudentsSubjectsConfiguration : IEntityTypeConfiguration<StudentsSubjects>
{
    public void Configure(EntityTypeBuilder<StudentsSubjects> builder)
    {
        builder.Property(x => x.Grade)
                .HasPrecision(5, 2);
    }
}