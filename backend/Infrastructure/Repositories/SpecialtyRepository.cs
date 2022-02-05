using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SpecialtyRepository : Repository<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(UniversityContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Specialty>> GetAllByBranch(int branchId)
        {
            var entities = await _set.Where(spec => spec.KnowledgeBranchId == branchId).ToListAsync();

            return entities;
        }
    }
}
