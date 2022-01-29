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

        public IRepository<Teacher> Teachers => Repository<Teacher>();

        public IRepository<HeadOfSmc> HeadsOfSmc => Repository<HeadOfSmc>();

        public IRepository<Guarantor> Guarantors => Repository<Guarantor>();

        public IRepository<KnowledgeBranch> KnowledgeBranches => Repository<KnowledgeBranch>();

        public IRepository<Specialty> Specialties => Repository<Specialty>();

        public IRepository<Subject> Subjects => Repository<Subject>();

        public IRepository<Syllabus> Syllabuses => Repository<Syllabus>();

        public IRepository<TeacherLoad> TeacherLoads => Repository<TeacherLoad>();

        public UnitOfWork(UniversityContext context)
        {
            _context = context;

            _repositories[typeof(Teacher)] = new Repository<Teacher>(_context);
            _repositories[typeof(HeadOfSmc)] = new Repository<HeadOfSmc>(_context);
            _repositories[typeof(Guarantor)] = new Repository<Guarantor>(_context);
            _repositories[typeof(KnowledgeBranch)] = new Repository<KnowledgeBranch>(_context);
            _repositories[typeof(Specialty)] = new Repository<Specialty>(_context);
            _repositories[typeof(Subject)] = new Repository<Subject>(_context);
            _repositories[typeof(Syllabus)] = new Repository<Syllabus>(_context);
            _repositories[typeof(TeacherLoad)] = new Repository<TeacherLoad>(_context);
        }

        public IRepository<TEntity> Repository<TEntity>()
            where TEntity : Entity, new()
        {
            var entityType = typeof(TEntity);

            if (!_repositories.ContainsKey(entityType))
            {
                _repositories.Add(entityType, new Repository<TEntity>(_context));
            }

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
