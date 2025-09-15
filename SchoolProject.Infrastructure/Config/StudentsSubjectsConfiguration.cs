using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolProject.Infrastructure.Config;

public class StudentsSubjectsConfiguration : IEntityTypeConfiguration<StudentSubjects>
{
	public void Configure(EntityTypeBuilder<StudentSubjects> builder)
	{
		builder.Property(x => x.Grade)
			.HasPrecision(5, 2);
	}
}