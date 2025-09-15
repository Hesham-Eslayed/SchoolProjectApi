using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SchoolProject.Domain.Identity;
using SchoolProject.Infrastructure.Config;

namespace SchoolProject.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
	: IdentityDbContext<User, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>,
		IdentityRoleClaim<int>, IdentityUserToken<int>>(options)
{
	public override DbSet<User> Users { get; set; }

	public DbSet<Student> Students { get; set; }

	public DbSet<Subject> Subjects { get; set; }

	public DbSet<Department> Departments { get; set; }

	public DbSet<Instructor> Instructors { get; set; }

	public DbSet<StudentSubjects> StudentsSubjects { get; set; }

	public DbSet<DepartmentSubjects> DepartmentsSubjects { get; set; }

	public DbSet<InstructorSubjects> InstructorsSubjects { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubjectConfiguration).Assembly);

		base.OnModelCreating(modelBuilder);
	}
}