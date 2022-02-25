using Assignment11_EFCore_2.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace Assignment11_EFCore_2.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MyDbContext _context;
        private DbSet<T> _entities;

        public GenericRepository(MyDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
        public async Task<IList<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        } 
        public T? Get(int id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }
        public async Task<T?> GetAsync(int id)
        {
            return await _entities.SingleOrDefaultAsync(s => s.Id == id);
        }
        
        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public async Task<T?> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public async Task<T?> UpdateAsync(T entity)
        {
             if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }    
        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}

