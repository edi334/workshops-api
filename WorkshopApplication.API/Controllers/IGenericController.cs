using Microsoft.AspNetCore.Mvc;
using WorkshopApplication.Core;

namespace WorkshopApplication.API.Controllers;

public interface IGenericController<TDto>
{
    Task<ActionResult<List<TDto>>> GetAll();
    Task<ActionResult<TDto>> GetById(Guid id);
    Task<ActionResult<TDto>> Add(TDto entityDto);
    Task<ActionResult<TDto>> Update(TDto entityDto);
    Task<ActionResult<TDto>> Delete(TDto entityDto);
}