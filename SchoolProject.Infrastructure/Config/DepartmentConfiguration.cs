using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SchoolProject.Infrastructure.Config;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(x => x.DID);

        builder.HasIndex(x => x.ManagerId);

        builder.HasOne(x => x.Manager)
            .WithOne()
            .HasForeignKey<Department>(x => x.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);

        #region Properties

        builder.Property(x => x.DNameEn)
            .HasMaxLength(100);

        builder.Property(x => x.DNameAr)
           .HasColumnType("NVarChar(100)");

        #endregion Properties
    }
}