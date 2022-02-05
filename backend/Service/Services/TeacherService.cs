using AutoMapper;
using Core;
using Core.DTOs;
using Core.Entities;
using Core.Services;

namespace Service.Services
{
    public class TeacherService : EntityService<Teacher, TeacherDTO>, ITeacherService
    {
        public TeacherService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }
    }
}
