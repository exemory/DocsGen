using AutoMapper;
using Core;
using Core.DTOs;
using Core.Entities;
using Core.Services;

namespace Service.Services
{
    public class SpecialtyService : EntityService<Specialty, SpecialtyDTO>, ISpecialtyService
    {
        public SpecialtyService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<SpecialtyDTO>> GetAllByBranch(int branchId)
        {
            var specialties = await _unitOfWork.Specialties.GetAllByBranch(branchId);
            var dtos = MapToDTO(specialties);

            return dtos;
        }
    }
}
