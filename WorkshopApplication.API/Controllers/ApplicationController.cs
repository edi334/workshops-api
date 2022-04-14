using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkshopApplication.API.Dtos;
using WorkshopApplication.Core;
using WorkshopApplication.Infrastructure.Repo;

namespace WorkshopApplication.API.Controllers;

[ApiController]
[Route("/api/application")]
public class ApplicationController : ControllerBase
{
    private readonly IGenericRepository<Application> _repository;
    private readonly IMapper _mapper;

    public ApplicationController(IGenericRepository<Application> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<ActionResult<List<ApplicationResponseDto>>> GetAll()
    {
        var applications = await _repository.GetAllAsync();
        var response = _mapper.Map<List<ApplicationResponseDto>>(applications);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApplicationResponseDto>> GetById(Guid id)
    {
        var application = await _repository.GetByIdAsync(id);

        if (application is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<ApplicationResponseDto>(application);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ApplicationResponseDto>> Add(ApplicationRequestDto entityDto)
    {
        var application = _mapper.Map<Application>(entityDto);
        var response = _mapper.Map<ApplicationResponseDto>( await _repository.AddAsync(application));

        return Ok(response);
    }

    [HttpPatch]
    public async Task<ActionResult<ApplicationResponseDto>> Update(ApplicationRequestDto entityDto)
    {
        var application = _mapper.Map<Application>(entityDto);
        var response = _mapper.Map<ApplicationResponseDto>(await _repository.UpdateAsync(application));

        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult<ApplicationDto>> Delete(ApplicationDto entityDto)
    {
        var application = _mapper.Map<Application>(entityDto);
        var response =_mapper.Map<ApplicationResponseDto>(await _repository.DeleteAsync(application));

        return Ok(response);
    }
}