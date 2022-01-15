using Microsoft.EntityFrameworkCore;

namespace DocsGen.Models
{
    public class UniversityContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; } = default!;
        public DbSet<HeadOfSMC> HeadsOfSMC { get; set; } = default!;
        public DbSet<Guarantor> Guarantors { get; set; } = default!;

        public DbSet<KnowledgeBranch> KnowledgeBranches { get; set; } = default!;
        public DbSet<Speciality> Specialties { get; set; } = default!;

        public DbSet<Subject> Subjects { get; set; } = default!;
        public DbSet<Syllabus> Syllabuses { get; set; } = default!;
        public DbSet<TeacherLoad> TeacherLoads { get; set; } = default!;

        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KnowledgeBranch>()
                .HasIndex(e => e.Code)
                .IsUnique();

            modelBuilder.Entity<Speciality>()
                .HasIndex(e => e.Code)
                .IsUnique();

            modelBuilder.Entity<Subject>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<TeacherLoad>()
                .HasIndex(e => new { e.Type, e.Year, e.TeacherId, e.SubjectId, e.SpecialityId })
                .IsUnique();
        }
    }
}
