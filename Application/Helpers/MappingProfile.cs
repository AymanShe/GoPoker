using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameDto>().ReverseMap();

            CreateMap<PlayerCard, PlayerCardDto>().ReverseMap();

            CreateMap<ShoeCard, ShoeCardDto>().ReverseMap();

            CreateMap<Player, AddPlayerDto>().ReverseMap();
            CreateMap<Player, GetPlayerDto>().ReverseMap();
        }
    }
}
