using Microsoft.EntityFrameworkCore;
using WesaamEcomerce.EntityFramework;
using WesaamEcomerce.EntityFramework.Models;

namespace WesaamEcomerce.Services
{
    public class BaseServices<T> : IServices<T> where T : BaseModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> entities;
        protected ApplicationDbContext DbContext { get => _dbContext; }

        public BaseServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = dbContext.Set<T>();

        }

        public async ValueTask<T?> GetByIdAsync(int id)
        {
            var entity = await entities.SingleOrDefaultAsync(e => e.IsActive && e.Id == id);

            return entity;
        }

        public async ValueTask<List<T>?> GetAllAsync()
        {
            return await entities.Where(e => e.IsActive).ToListAsync();
        }

        public async Task<int> CreateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }
        public async Task DeleteAsync(int id)
        {
            var entityFromDb = await GetByIdAsync(id);
            if (entityFromDb != null)
            {
                entityFromDb.IsActive = false;
                await UpdateAsync(entityFromDb, id);
            }
        }


        public async Task UpdateAsync(T entity, int id)
        {
            var entityFromDb = await GetByIdAsync(id);
            if (entityFromDb != null)
            {
                entity.Id = entityFromDb.Id;
                _dbContext.Entry(entityFromDb).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}