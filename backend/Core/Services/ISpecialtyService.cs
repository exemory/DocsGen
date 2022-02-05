using Core.DTOs;

namespace Core.Services
{
    public interface ISpecialtyService : IEntityService<SpecialtyDTO>
    {
        public Task<IEnumerable<SpecialtyDTO>> GetAllByBranch(int branchId);
    }
}
