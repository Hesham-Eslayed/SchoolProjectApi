using SchoolProject.Infrastructure.Config;

namespace SchoolProject.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }

    public DbSet<Subject> Subjects { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Instructor> Instructors { get; set; }

    public DbSet<StudentsSubjects> StudentsSubjects { get; set; }

    public DbSet<DepartmentsSubjects> DepartmentsSubjects { get; set; }

    public DbSet<InstructorsSubjects> InstructorsSubjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SubjectConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }


}