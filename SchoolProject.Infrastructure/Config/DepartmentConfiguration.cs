using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolProject.Infrastructure.Config;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasIndex(x => x.ManagerId).IsUnique();

        builder.HasOne(x => x.Manager)
            .WithOne()
            .HasForeignKey<Department>(x => x.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}