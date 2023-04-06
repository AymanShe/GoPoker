using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PlayerCard, PlayerCardDto>().ReverseMap();
        }
    }
}
