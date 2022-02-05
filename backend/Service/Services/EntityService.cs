using AutoMapper;
using Core;
using Core.DTOs.Base;
using Core.Entities.Base;
using Core.Exceptions;
using Core.Services;

namespace Service.Services
{
    public class EntityService<TEntity, TDTO> : IEntityService<TDTO>
        where TEntity : Entity, new()
        where TDTO : DTO
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public EntityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TDTO> GetById(int id)
        {
            var entity = await _unitOfWork.Repository<TEntity>().GetById(id);
            if (entity == null)
            {
                throw new EntityNotFoundException("Entity doesn't exist in the repository.", typeof(TEntity));
            }

            var dto = MapToDTO(entity);
            return dto;
        }

        public async Task<IEnumerable<TDTO>> GetAll()
        {
            var entities = await _unitOfWork.Repository<TEntity>().GetAll();
            var dtos = MapToDTO(entities);
            return dtos;
        }

        public async Task<TDTO> Add(TDTO dto)
        {
            var entity = MapToEntity(dto);
            entity.Id = default;

            _unitOfWork.Repository<TEntity>().Add(entity);

            await _unitOfWork.Save();

            dto = MapToDTO(entity);
            return dto;
        }

        public async Task Update(TDTO dto)
        {
            var entity = MapToEntity(dto);

            var exists = await _unitOfWork.Repository<TEntity>().Exists(entity);
            if (!exists)
            {
                throw new EntityNotFoundException("Entity doesn't exist in the repository.", typeof(TEntity));
            }

            _unitOfWork.Repository<TEntity>().Update(entity);
            await _unitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            var exists = await _unitOfWork.Repository<TEntity>().Exists(id);
            if (!exists)
            {
                throw new EntityNotFoundException("Entity doesn't exist in the repository.", typeof(TEntity));
            }

            _unitOfWork.Repository<TEntity>().Delete(id);

            await _unitOfWork.Save();
        }

        protected TEntity MapToEntity(TDTO dto)
        {
            return _mapper.Map<TDTO, TEntity>(dto);
        }
        protected IEnumerable<TEntity> MapToEntity(IEnumerable<TDTO> dtos)
        {
            return _mapper.Map<IEnumerable<TDTO>, IEnumerable<TEntity>>(dtos);
        }

        protected IEnumerable<TDTO> MapToDTO(IEnumerable<TEntity> entities)
        {
            return _mapper.Map<IEnumerable<TEntity>, IEnumerable<TDTO>>(entities);
        }

        protected TDTO MapToDTO(TEntity entity)
        {
            return _mapper.Map<TEntity, TDTO>(entity);
        }
    }
}
