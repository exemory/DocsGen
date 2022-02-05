using AutoMapper;
using Core;
using Core.DTOs;
using Core.Entities;
using Core.Services;

namespace Service.Services
{
    public class HeadOfSmcService : EntityService<HeadOfSmc, HeadOfSmcDTO>, IHeadOfSmcService
    {
        public HeadOfSmcService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }
    }
}
