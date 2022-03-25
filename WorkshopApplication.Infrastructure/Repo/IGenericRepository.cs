using System.Diagnostics;
using Microsoft.Extensions.Options;
using WorkshopApplication.Core;

namespace WorkshopApplication.Infrastructure.Repo;

public interface IGenericRepository<T> where T : BaseEntity
{ 
    Task<ICollection<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}