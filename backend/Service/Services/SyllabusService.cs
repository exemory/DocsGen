using AutoMapper;
using Core;
using Core.DTOs;
using Core.Entities;
using Core.Services;

namespace Service.Services
{
    public class SyllabusService : EntityService<Syllabus, SyllabusDTO>, ISyllabusService
    {
        public SyllabusService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }
    }
}
