using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WorkshopApplication.API.Dtos;
using WorkshopApplication.Core;
using WorkshopApplication.Infrastructure.Repo;

namespace WorkshopApplication.API.Controllers;

[ApiController]
[Route("/api/participant")]
public class ParticipantController : ControllerBase, IGenericController<ParticipantDto>
{
    private readonly IGenericRepository<Participant> _repository;
    private readonly IMapper _mapper;

    public ParticipantController(IGenericRepository<Participant> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ParticipantDto>>> GetAll()
    {
        var participants = await _repository.GetAllAsync();
        var response = _mapper.Map<List<ParticipantDto>>(participants);

        return Ok(response);
    }

    [HttpGet("{entityId}")]
    public async Task<ActionResult<ParticipantDto>> GetById([FromRoute] Guid entityId)
    {
        var participant = await _repository.GetByIdAsync(entityId);

        if (participant is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<ParticipantDto>(participant);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ParticipantDto>> Add(ParticipantDto entityDto)
    {
        var participant = _mapper.Map<Participant>(entityDto);
        var response = _mapper.Map<ParticipantDto>(await _repository.AddAsync(participant));

        return Ok(response);
    }

    [HttpPatch("{entityId}")]
    public async Task<ActionResult<ParticipantDto>> Update([FromRoute] Guid entityId, ParticipantDto entityDto)
    {
        var existingParticipant = await _repository.GetByIdAsync(entityId);

        if (existingParticipant is null)
        {
            return BadRequest("Participant not found!");
        }

        existingParticipant.FirstName = entityDto.FirstName;
        existingParticipant.LastName = entityDto.LastName;
        existingParticipant.PhoneNumber = entityDto.PhoneNumber;
        existingParticipant.Email = entityDto.Email;
        
        var response = _mapper.Map<ParticipantDto>(await _repository.UpdateAsync(existingParticipant));

        return Ok(response);
    }

    [HttpDelete("{entityId}")]
    public async Task<ActionResult<ParticipantDto>> Delete([FromRoute] Guid entityId)
    {
        var response = _mapper.Map<ParticipantDto>(await _repository.DeleteAsync(entityId));
        return Ok(response);
    }
}