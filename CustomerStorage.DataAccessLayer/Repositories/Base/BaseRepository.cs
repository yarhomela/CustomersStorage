
using Microsoft.EntityFrameworkCore;

namespace CustomerStorage.DataAccessLayer.Repositories.Base
{
    public class BaseRepository<TEntity> where TEntity : Entities.Base.Base
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task CreateRangeAsync(List<TEntity> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> ReadByIdAsync(int id)
        {
            var entity = await _context.FindAsync<TEntity>(id);
            return entity;
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateRangeAsync(List<TEntity> entities)
        {
            _context.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
        public virtual async Task DeleteAsync(int id)
        {
            Entities.Base.Base entity = new Entities.Base.Base() { Id = id };
            _context.Attach(entity);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
