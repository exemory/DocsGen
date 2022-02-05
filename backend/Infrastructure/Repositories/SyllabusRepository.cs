using Core.Entities;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class SyllabusRepository : Repository<Syllabus>, ISyllabusRepository
    {
        public SyllabusRepository(UniversityContext context) : base(context)
        {
        }
    }
}
