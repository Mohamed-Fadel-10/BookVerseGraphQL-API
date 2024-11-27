namespace BookVerseGraphQL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {

        public  Task<T> AddAsync(T Model);
        Task<IQueryable<T>> GetAllAsync();
        public Task<T>? GetByIDAsync(int id);
        public Task<T> UpdateAsync(T model, int id);
        public bool Delete(int id);
    }
}
