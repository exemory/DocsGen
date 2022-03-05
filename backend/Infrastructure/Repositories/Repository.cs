using Core.Entities.Base;
using Core.Exceptions;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly UniversityContext Context;
        protected readonly DbSet<T> Set;

        public Repository(UniversityContext context)
        {
            Context = context;
            Set = Context.Set<T>();
        }

        public async Task<T> GetById(int entityId)
        {
            var entity = await Set.FindAsync(entityId);

            if (entity == null)
            {
                throw new EntityNotFoundException("Entity not found.", typeof(T));
            }

            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var entities = await Set.ToListAsync();

            return entities;
        }

        public DbSet<T> Get()
        {
            return Set;
        }

        public void Add(T entity)
        {
            Set.Add(entity);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int entityId)
        {
            Delete(new T { Id = entityId });
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
        }
        
        public void DeleteRange(IEnumerable<int> entityIds)
        {
            DeleteRange(entityIds.Select(id => new T {Id = id}));
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            Set.RemoveRange(entities);
        }

        public async Task<bool> Exists(int entityId)
        {
            var exists = await Set.AnyAsync(entity => entity.Id == entityId);

            return exists;
        }

        public async Task<bool> Exists(T entity)
        {
            var exists = await Exists(entity.Id);

            return exists;
        }
    }
}
