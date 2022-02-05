using Core.Entities;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class TeacherLoadRepository : Repository<TeacherLoad>, ITeacherLoadRepository
    {
        public TeacherLoadRepository(UniversityContext context) : base(context)
        {
        }
    }
}
