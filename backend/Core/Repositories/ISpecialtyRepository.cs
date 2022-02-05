using Core.Entities;

namespace Core.Repositories
{
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
        Task<IEnumerable<Specialty>> GetAllByBranch(int branchId);
    }
}
