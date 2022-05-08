using AutoMapper;
using WorkshopApplication.API.Dtos;
using WorkshopApplication.Core;

namespace WorkshopApplication.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Application, ApplicationResponseDto>().ReverseMap();
        CreateMap<Application, ApplicationRequestDto>().ReverseMap();
        CreateMap<Workshop, WorkshopDto>().ReverseMap();
        CreateMap<Participant, ParticipantDto>().ReverseMap();
    }
}