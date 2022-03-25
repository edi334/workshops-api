using Microsoft.AspNetCore.Mvc;
using WorkshopApplication.Core;

namespace WorkshopApplication.API.Api;

public abstract class GenericController<T> : ControllerBase, IGenericController<T> where T : BaseEntity
{
    public Task<List<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<T> Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> Update(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> Delete(T entity)
    {
        throw new NotImplementedException();
    }
}