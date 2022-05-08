using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkshopApplication.API.Dtos;
using WorkshopApplication.Core;
using WorkshopApplication.Infrastructure.Repo;

namespace WorkshopApplication.API.Controllers;

[ApiController]
[Route("/api/workshop")]
public class WorkshopController : ControllerBase, IGenericController<WorkshopDto>
{
    private readonly IGenericRepository<Workshop> _repository;
    private readonly IMapper _mapper;

    public WorkshopController(IGenericRepository<Workshop> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<WorkshopDto>>> GetAll()
    {
        var workshops = await _repository.GetAllAsync();
        var response = _mapper.Map<List<WorkshopDto>>(workshops);

        return Ok(response);
    }

    [HttpGet("{entityId}")]
    public async Task<ActionResult<WorkshopDto>> GetById([FromRoute] Guid entityId)
    {
        var workshop = await _repository.GetByIdAsync(entityId);

        if (workshop is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<WorkshopDto>(workshop);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<WorkshopDto>> Add(WorkshopDto entityDto)
    {
        var workshop = _mapper.Map<Workshop>(entityDto);
        var response = _mapper.Map<WorkshopDto>(await _repository.AddAsync(workshop));

        return Ok(response);
    }

    [HttpPatch("{entityId}")]
    public async Task<ActionResult<WorkshopDto>> Update([FromRoute] Guid entityId, WorkshopDto entityDto)
    {
        var existingWorkshop = await _repository.GetByIdAsync(entityId);

        if (existingWorkshop is null)
        {
            return BadRequest("Workshop not found!");
        }

        existingWorkshop.Name = entityDto.Name;
        existingWorkshop.Description = entityDto.Description;
        existingWorkshop.Category = entityDto.Category;
        
        var response = _mapper.Map<WorkshopDto>(await _repository.UpdateAsync(existingWorkshop));

        return Ok(response);
    }

    [HttpDelete("{entityId}")]
    public async Task<ActionResult<WorkshopDto>> Delete([FromRoute] Guid entityId)
    {
        var response = _mapper.Map<WorkshopDto>(await _repository.DeleteAsync(entityId));
        return Ok(response);
    }
}