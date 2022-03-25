using Microsoft.EntityFrameworkCore;
using WorkshopApplication.Core;

namespace WorkshopApplication.Infrastructure.Repo;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly DbSet < T > _entities;
    private readonly ApplicationDbContext _dbContext;

    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = dbContext.Set<T>();
    }
    
    public async Task<ICollection<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _entities.SingleOrDefaultAsync(e => e.Id == id);
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

    public async Task<T> DeleteAsync(T entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException("Entity null!");
        }

        _entities.Remove(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }
}