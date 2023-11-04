using Microsoft.EntityFrameworkCore;
using practice_proyect.Context;

namespace practice_proyect.Repository.Generic
{
    public class GenericRepository<T, ID> : IGenericRepository<T, ID> where T : class
    {
        private readonly FirstContext _firstContext;
        private readonly DbSet<T> _entities;

        public GenericRepository(FirstContext firstContext) { 
            _firstContext = firstContext;
            _entities = firstContext.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            _entities.Add(entity);
            await SaveAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> FindByIdAsync(ID id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _firstContext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _firstContext.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
            return entity;
        }

        public async Task<List<T>> CreateMultipleAsync(List<T> entities) {
            await _firstContext.AddRangeAsync(entities);
            await SaveAsync();
            return entities;
        }
    }
}
