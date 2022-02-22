using Core.Entities.Base;
using Core.Repositories;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        public ITeacherRepository Teachers { get; }

        public IHeadOfSmcRepository HeadsOfSmc { get; }

        public IGuarantorRepository Guarantors { get; }

        public IKnowledgeBranchRepository KnowledgeBranches { get; }

        public ISpecialtyRepository Specialties { get; }

        public ISubjectRepository Subjects { get; }

        public ISyllabusRepository Syllabuses { get; }

        public ITeacherLoadRepository TeacherLoads { get; }

        public ITemplateRepository Templates { get; }

        public IRepository<TEntity> Repository<TEntity>()
            where TEntity : Entity, new();

        public Task Save();

        public void Rollback();
    }
}
