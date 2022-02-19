using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class UniversityContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<HeadOfSmc> HeadsOfSmc { get; set; } = null!;
        public DbSet<Guarantor> Guarantors { get; set; } = null!;

        public DbSet<KnowledgeBranch> KnowledgeBranches { get; set; } = null!;
        public DbSet<Specialty> Specialties { get; set; } = null!;

        public DbSet<Subject> Subjects { get; set; } = null!;
        public DbSet<Syllabus> Syllabuses { get; set; } = null!;
        public DbSet<TeacherLoad> TeacherLoads { get; set; } = null!;
        
        public DbSet<Template> Templates { get; set; } = null!;

        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KnowledgeBranch>()
                .HasIndex(e => e.Code)
                .IsUnique();

            modelBuilder.Entity<Specialty>()
                .HasIndex(e => e.Code)
                .IsUnique();

            modelBuilder.Entity<Subject>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<TeacherLoad>()
                .HasIndex(e => new { e.Type, e.Year, e.TeacherId, e.SubjectId, e.SpecialtyId })
                .IsUnique();
        }
    }
}
