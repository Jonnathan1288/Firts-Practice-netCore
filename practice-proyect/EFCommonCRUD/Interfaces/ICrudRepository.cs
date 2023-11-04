namespace practice_proyect.EFCommonCRUD.Interfaces
{
    public interface ICrudRepository<T, ID> where T : class 
    {
        public long Count();
        public Task<long> CountAsync();


        public int Delete(T entity);
        public Task<int> DeleteAsync(T entity);

        public int DeleteAllById(IEnumerable<ID> ids);
        public Task<int> DeleteAllByIdsync(IEnumerable<ID> ids);

        public int DeleteById(ID id);
        public Task<int> DeleteByIdAsync(ID id);


        public bool ExistById(ID id);
        public Task<bool> ExistByIdAsync(ID id);


        public IEnumerable<T> FindAll();
        public Task<IEnumerable<T>> FindAllAsync();

        public IEnumerable<T> FindAllById(IEnumerable<ID> ids);

        public T Save(T entity);
        public ValueTask<T> SaveAsync(T entity);
        public IEnumerable<T> SaveAll(IEnumerable<T> entities);
        public Task<IEnumerable<T>> SaveAllAsync(IEnumerable<T> entities);

        public T Update(T entity);
        public ValueTask<T> UpdateAsync(T entity);
        public IEnumerable<T> UpdateAll(IEnumerable<T> entities);
        public Task<IEnumerable<T>> UpdateAllAsync(IEnumerable<T> entities);

    }
}
