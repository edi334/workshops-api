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

    [HttpGet("{id}")]
    public async Task<ActionResult<WorkshopDto>> GetById(Guid id)
    {
        var workshop = await _repository.GetByIdAsync(id);

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

    [HttpPatch]
    public async Task<ActionResult<WorkshopDto>> Update(WorkshopDto entityDto)
    {
        var workshop = _mapper.Map<Workshop>(entityDto);
        var response = _mapper.Map<WorkshopDto>(await _repository.UpdateAsync(workshop));

        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult<WorkshopDto>> Delete(WorkshopDto entityDto)
    {
        var workshop = _mapper.Map<Workshop>(entityDto);
        var response = _mapper.Map<WorkshopDto>(await _repository.DeleteAsync(workshop));

        return Ok(response);
    }
}