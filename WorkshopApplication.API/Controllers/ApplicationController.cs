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
    private readonly IGenericRepository<Participant> _participantRepo;
    private readonly IGenericRepository<Workshop> _workshopRepo;
    private readonly IMapper _mapper;

    public ApplicationController(IGenericRepository<Application> repository, IMapper mapper, IGenericRepository<Workshop> workshopRepo, IGenericRepository<Participant> participantRepo)
    {
        _repository = repository;
        _mapper = mapper;
        _workshopRepo = workshopRepo;
        _participantRepo = participantRepo;
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
        application.Participant = await _participantRepo.GetByIdAsync(Guid.Parse(entityDto.ParticipantId));
        application.Workshop = await _workshopRepo.GetByIdAsync(Guid.Parse(entityDto.WorkshopId));
        //var response = _mapper.Map<ApplicationResponseDto>( await _repository.AddAsync(application));

        return Ok(application);
    }

    [HttpPatch]
    public async Task<ActionResult<ApplicationResponseDto>> Update(ApplicationRequestDto entityDto)
    {
        var application = _mapper.Map<Application>(entityDto);
        var response = _mapper.Map<ApplicationResponseDto>(await _repository.UpdateAsync(application));

        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult<ApplicationResponseDto>> Delete(ApplicationRequestDto entityDto)
    {
        var application = _mapper.Map<Application>(entityDto);
        var response =_mapper.Map<ApplicationResponseDto>(await _repository.DeleteAsync(application));

        return Ok(response);
    }
}