using AutoMapper;
using Core;
using Core.DTOs.Base;
using Core.Entities.Base;
using Core.Services;

namespace Service.Services
{
    public class EntityService<TEntity, TDTO> : IEntityService<TDTO>
        where TEntity : Entity, new()
        where TDTO : DTO
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;

        protected EntityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<TDTO> GetById(int id)
        {
            var entity = await UnitOfWork.Repository<TEntity>().GetById(id);
            var dto = MapToDTO(entity);
            return dto;
        }

        public async Task<IEnumerable<TDTO>> GetAll()
        {
            var entities = await UnitOfWork.Repository<TEntity>().GetAll();
            var dtos = MapToDTO(entities);
            return dtos;
        }

        public async Task<TDTO> Add(TDTO dto)
        {
            var entity = MapToEntity(dto);
            entity.Id = default;

            UnitOfWork.Repository<TEntity>().Add(entity);

            await UnitOfWork.Save();

            dto = MapToDTO(entity);
            return dto;
        }

        public async Task Update(TDTO dto)
        {
            var entity = MapToEntity(dto);

            UnitOfWork.Repository<TEntity>().Update(entity);
            await UnitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            UnitOfWork.Repository<TEntity>().Delete(id);

            await UnitOfWork.Save();
        }

        protected TEntity MapToEntity(TDTO dto)
        {
            return Mapper.Map<TDTO, TEntity>(dto);
        }
        
        protected IEnumerable<TEntity> MapToEntity(IEnumerable<TDTO> dtos)
        {
            return Mapper.Map<IEnumerable<TDTO>, IEnumerable<TEntity>>(dtos);
        }

        protected IEnumerable<TDTO> MapToDTO(IEnumerable<TEntity> entities)
        {
            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDTO>>(entities);
        }

        protected TDTO MapToDTO(TEntity entity)
        {
            return Mapper.Map<TEntity, TDTO>(entity);
        }
    }
}
