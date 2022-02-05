using Core;
using Core.Entities;
using Core.Entities.Base;
using Core.Repositories;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly UniversityContext _context;

        private readonly Dictionary<Type, dynamic> _repositories = new();

        public ITeacherRepository Teachers => _repositories[typeof(Specialty)];

        public IHeadOfSmcRepository HeadsOfSmc => _repositories[typeof(Specialty)];

        public IGuarantorRepository Guarantors => _repositories[typeof(Specialty)];

        public IKnowledgeBranchRepository KnowledgeBranches => _repositories[typeof(Specialty)];

        public ISpecialtyRepository Specialties => _repositories[typeof(Specialty)];

        public ISubjectRepository Subjects => _repositories[typeof(Specialty)];

        public ISyllabusRepository Syllabuses => _repositories[typeof(Specialty)];

        public ITeacherLoadRepository TeacherLoads => _repositories[typeof(Specialty)];

        public UnitOfWork(UniversityContext context)
        {
            _context = context;

            _repositories[typeof(Teacher)] = new TeacherRepository(_context);
            _repositories[typeof(HeadOfSmc)] = new HeadOfSmcRepository(_context);
            _repositories[typeof(Guarantor)] = new GuarantorRepository(_context);
            _repositories[typeof(KnowledgeBranch)] = new KnowledgeBranchRepository(_context);
            _repositories[typeof(Specialty)] = new SpecialtyRepository(_context);
            _repositories[typeof(Subject)] = new SubjectRepository(_context);
            _repositories[typeof(Syllabus)] = new SyllabusRepository(_context);
            _repositories[typeof(TeacherLoad)] = new TeacherLoadRepository(_context);
        }

        public IRepository<TEntity> Repository<TEntity>()
            where TEntity : Entity, new()
        {
            var entityType = typeof(TEntity);

            return _repositories[entityType];
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