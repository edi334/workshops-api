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

    [HttpGet("{id}")]
    public async Task<ActionResult<ParticipantDto>> GetById(Guid id)
    {
        var participant = await _repository.GetByIdAsync(id);

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

    [HttpPatch]
    public async Task<ActionResult<ParticipantDto>> Update(ParticipantDto entityDto)
    {
        var participant = _mapper.Map<Participant>(entityDto);
        var response = _mapper.Map<ParticipantDto>(await _repository.UpdateAsync(participant));

        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult<ParticipantDto>> Delete(ParticipantDto entityDto)
    {
        var participant = _mapper.Map<Participant>(entityDto);
        var response = _mapper.Map<ParticipantDto>(await _repository.DeleteAsync(participant));

        return Ok(response);
    }
}