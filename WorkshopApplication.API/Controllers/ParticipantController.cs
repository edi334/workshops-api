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

    [HttpGet]
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

    public Task<ActionResult<ParticipantDto>> Add(ParticipantDto entityDto)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<ParticipantDto>> Update(ParticipantDto entityDto)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<ParticipantDto>> Delete(ParticipantDto entityDto)
    {
        throw new NotImplementedException();
    }
}