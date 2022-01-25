using Core.Entities;
using Core.Repositories;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Teacher> Teachers { get; }

        public IRepository<HeadOfSmc> HeadsOfSmc { get; }

        public IRepository<Guarantor> Guarantors { get; }

        public IRepository<KnowledgeBranch> KnowledgeBranches { get; }

        public IRepository<Specialty> Specialties { get; }

        public IRepository<Subject> Subjects { get; }

        public IRepository<Syllabus> Syllabuses { get; }

        public IRepository<TeacherLoad> TeacherLoads { get; }

        public Task Save();
    }
}
