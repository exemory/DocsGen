using Core.Entities;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(UniversityContext context) : base(context)
        {
        }
    }
}
