using Core.Entities;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class KnowledgeBranchRepository : Repository<KnowledgeBranch>, IKnowledgeBranchRepository
    {
        public KnowledgeBranchRepository(UniversityContext context) : base(context)
        {
        }
    }
}
