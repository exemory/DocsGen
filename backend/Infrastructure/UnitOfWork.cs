using Core;
using Core.Entities;
using Core.Repositories;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly UniversityContext _context;

        public IRepository<Teacher> Teachers { get; }

        public IRepository<HeadOfSmc> HeadsOfSmc { get; }

        public IRepository<Guarantor> Guarantors { get; }

        public IRepository<KnowledgeBranch> KnowledgeBranches { get; }

        public IRepository<Specialty> Specialties { get; }

        public IRepository<Subject> Subjects { get; }

        public IRepository<Syllabus> Syllabuses { get; }

        public IRepository<TeacherLoad> TeacherLoads { get; }

        public UnitOfWork(UniversityContext context)
        {
            _context = context;

            Teachers = new Repository<Teacher>(_context);
            HeadsOfSmc = new Repository<HeadOfSmc>(_context);
            Guarantors = new Repository<Guarantor>(_context);
            KnowledgeBranches = new Repository<KnowledgeBranch>(_context);
            Specialties = new Repository<Specialty>(_context);
            Subjects = new Repository<Subject>(_context);
            Syllabuses = new Repository<Syllabus>(_context);
            TeacherLoads = new Repository<TeacherLoad>(_context);
        }   

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
