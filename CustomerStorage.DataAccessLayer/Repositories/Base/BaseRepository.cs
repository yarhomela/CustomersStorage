
namespace CustomerStorage.DataAccessLayer.Repositories.Base
{
    public class BaseRepository<TEntity> where TEntity : Entities.Base.Base
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task Create(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task CreateRange(List<TEntity> entities)
        {
            await _context.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> ReadById(int id)
        {
            var entity = await _context.FindAsync<TEntity>(id);
            return entity;
        }

        public virtual async Task Update(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task UpdateRange(List<TEntity> entities)
        {
            _context.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
        public virtual async Task Delete(int id)
        {
            Entities.Base.Base entity = new Entities.Base.Base() { Id = id };
            _context.Attach(entity);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
