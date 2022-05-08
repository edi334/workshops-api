using Microsoft.EntityFrameworkCore;
using WorkshopApplication.Core;

namespace WorkshopApplication.Infrastructure.Repo;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly DbSet < T > _entities;
    private readonly ApplicationDbContext _dbContext;
    public IQueryable<T> _queryable { get; private set; }

    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = dbContext.Set<T>();
        _queryable = _entities;
    }
    
    public async Task<ICollection<T>> GetAllAsync()
    {
        return await _queryable.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _queryable.SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<T> AddAsync(T entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException("Entity null!");
        }

        await _entities.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException("Entity null!");
        }
        
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<T> DeleteAsync(Guid id)
    {
        var existingEntity = await _entities.FirstOrDefaultAsync(e => e.Id == id);
        
        if (existingEntity is null)
        {
            throw new ArgumentNullException("Entity null!");
        }

        _entities.Remove(existingEntity);
        await _dbContext.SaveChangesAsync();

        return existingEntity;
    }
    
    public void ChainQueryable(Func<IQueryable<T>, IQueryable<T>> func)
    {
        _queryable = func(_queryable);
    }
}