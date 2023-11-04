namespace practice_proyect.Repository.Generic
{
    public interface IGenericRepository<T, ID> where T: class
    {
        public Task<IEnumerable<T>> FindAllAsync();
        public Task<T> FindByIdAsync(ID id);
        public Task<T> CreateAsync(T entity);
        public Task<List<T>> CreateMultipleAsync(List<T> entities);
        public Task<T> UpdateAsync(T entity);
        public Task SaveAsync();
    }
}
