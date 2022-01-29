using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace Service
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Guarantor, GuarantorDTO>();
            CreateMap<GuarantorDTO, Guarantor>();
        }
    }
}
