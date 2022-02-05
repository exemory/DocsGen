using AutoMapper;
using Core;
using Core.DTOs;
using Core.Entities;
using Core.Services;

namespace Service.Services
{
    public class KnowledgeBranchService : EntityService<KnowledgeBranch, KnowledgeBranchDTO>, IKnowledgeBranchService
    {
        public KnowledgeBranchService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }
    }
}
