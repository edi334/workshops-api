using WorkshopApplication.Core;

namespace WorkshopApplication.API.Api;

public interface IGenericController<T> where T : BaseEntity
{
    Task<List<T>> GetAll();
    Task<T> GetById(Guid id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
}