using Core.Entities;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(UniversityContext context) : base(context)
        {
        }
    }
}
