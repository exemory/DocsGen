using AutoMapper;
using Core;
using Core.DTOs;
using Core.Entities;
using Core.Services;

namespace Service.Services
{
    public class TeacherLoadService : EntityService<TeacherLoad, TeacherLoadDTO>, ITeacherLoadService
    {
        public TeacherLoadService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }
    }
}
