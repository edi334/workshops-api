using Microsoft.AspNetCore.Mvc;
using WorkshopApplication.API.Dtos;

namespace WorkshopApplication.API.Controllers;

public class WorkshopController : ControllerBase, IGenericController<WorkshopDto>
{
    public Task<ActionResult<List<WorkshopDto>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<WorkshopDto>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<WorkshopDto>> Add(WorkshopDto entityDto)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<WorkshopDto>> Update(WorkshopDto entityDto)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<WorkshopDto>> Delete(WorkshopDto entityDto)
    {
        throw new NotImplementedException();
    }
}