using Microsoft.AspNetCore.Mvc;
namespace WorkshopApplication.API.Controllers;

public interface IGenericController<TDto>
{
    Task<ActionResult<List<TDto>>> GetAll();
    Task<ActionResult<TDto>> GetById([FromRoute] Guid id);
    Task<ActionResult<TDto>> Add(TDto entityDto);
    Task<ActionResult<TDto>> Update([FromRoute] Guid entityId, TDto entityDto);
    Task<ActionResult<TDto>> Delete([FromRoute] Guid entityId);
}