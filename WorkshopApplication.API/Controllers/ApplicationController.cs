using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public ApplicationController(IGenericRepository<Application> repository,
        IMapper mapper, 
        IGenericRepository<Workshop> workshopRepo,
        IGenericRepository<Participant> participantRepo)
    {
        _repository = repository;
        _repository.ChainQueryable(q => q
            .Include(a => a.Workshop)
            .Include(a => a.Participant));
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

    [HttpGet("{entityId}")]
    public async Task<ActionResult<ApplicationResponseDto>> GetById(Guid entityId)
    {
        var application = await _repository.GetByIdAsync(entityId);

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
        application.WorkshopId = entityDto.WorkshopId;
        application.ParticipantId = entityDto.ParticipantId;
        var dbApplication = await _repository.AddAsync(application);
        
        var mappedWorkshop = _mapper.Map<WorkshopDto>(dbApplication.Workshop);
        var mappedParticipant = _mapper.Map<ParticipantDto>(dbApplication.Participant);
        var response = new ApplicationResponseDto
        {
            Country = dbApplication.Country,
            Reason = dbApplication.Reason,
            University = dbApplication.University,
            FieldOfStudy = dbApplication.FieldOfStudy,
            Workshop = mappedWorkshop,
            Participant = mappedParticipant
        };

        return Ok(response);
    }

    [HttpPatch("{entityId}")]
    public async Task<ActionResult<ApplicationResponseDto>> Update([FromRoute] Guid entityId, ApplicationRequestDto entityDto)
    {
        var existingApplication = await _repository.GetByIdAsync(entityId);

        if (existingApplication is null)
        {
            return BadRequest("Application doesn't exist!");
        }

        existingApplication.Country = entityDto.Country;
        existingApplication.University = entityDto.University;
        existingApplication.FieldOfStudy = entityDto.FieldOfStudy;
        existingApplication.Reason = entityDto.Reason;
        existingApplication.ParticipantId = entityDto.ParticipantId;
        existingApplication.WorkshopId = entityDto.WorkshopId;

        var response = _mapper.Map<ApplicationResponseDto>(await _repository.UpdateAsync(existingApplication));

        return Ok(response);
    }

    [HttpDelete("{entityId}")]
    public async Task<ActionResult<ApplicationResponseDto>> Delete([FromRoute] Guid entityId)
    {
        var response =_mapper.Map<ApplicationResponseDto>(await _repository.DeleteAsync(entityId));

        return Ok(response);
    }
}