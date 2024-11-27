using BookVerseGraphQL.Data;
using Microsoft.EntityFrameworkCore;

namespace BookVerseGraphQL.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T : class
    {
        private readonly Context _context;

        public GenericRepository(Context context) 
        { 
           _context = context;
        }

        public async Task<T> AddAsync(T Model)
        {
            await _context.Set<T>().AddAsync(Model);
            await _context.SaveChangesAsync();
            return Model;
        }
        public async Task< IQueryable<T>> GetAllAsync()
        {
            return _context.Set<T>().AsNoTracking();
        }


        public async Task<T>? GetByIDAsync(int id)
        {
            var Entity = await _context.Set<T>().FindAsync(id);
            return Entity;
        }

        public async Task<T?> UpdateAsync(T model, int id)
        {
            T entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                foreach (var property in _context.Entry(model).Properties)
                {
                    var currentValue = property.CurrentValue;
                    if (property.Metadata.Name != "Id" && currentValue != null)
                    {
                        _context.Entry(entity).Property(property.Metadata.Name).CurrentValue = currentValue;
                    }
                }

                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }



        public bool Delete(int id)
        {
            try
            {
                T Entity = _context.Set<T>().Find(id);
                _context.Set<T>().Remove(Entity);
                 _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot Delete this Entity");
            }
        }

    }
}
