using Core.Entities;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class HeadOfSmcRepository : Repository<HeadOfSmc>, IHeadOfSmcRepository
    {
        public HeadOfSmcRepository(UniversityContext context) : base(context)
        {
        }
    }
}
