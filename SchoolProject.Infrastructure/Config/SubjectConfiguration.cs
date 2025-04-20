using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolProject.Infrastructure.Config;
public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasMany(x => x.Students)
            .WithMany(x => x.Subjects)
            .UsingEntity<StudentSubject>();

        builder.HasMany(x => x.Departments)
           .WithMany(x => x.Subjects)
           .UsingEntity<DepartmentSubject>();

    }
}


