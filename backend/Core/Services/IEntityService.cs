using Core.DTOs.Base;

namespace Core.Services
{
    public interface IEntityService<T> where T : DTO
    {
        public Task<T> GetById(int id);

        public Task<IEnumerable<T>> GetAll();

        public Task<T> Add(T dto);

        public Task Update(T dto);

        public Task Delete(int id);
    }
}
