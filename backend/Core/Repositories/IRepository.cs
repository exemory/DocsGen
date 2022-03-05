using Core.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetById(int entityId);

        Task<IEnumerable<T>> GetAll();
        
        DbSet<T> Get();

        void Add(T entity);

        void Update(T entity);

        void Delete(int entityId);

        void Delete(T entity);
        
        void DeleteRange(IEnumerable<int> entityIds);

        void DeleteRange(IEnumerable<T> entities);

        Task<bool> Exists(int entityId);

        Task<bool> Exists(T entity);
    }
}
