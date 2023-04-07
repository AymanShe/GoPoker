using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }


        public GetPlayerDto AddPlayerToGame(AddPlayerDto playerDto)
        {
            //TODO validate game exists
            var player = new Player
            {
                GameId = playerDto.GameId,
                IsPlaying = true
            };

            player = _playerRepository.Add(player);
            
            return _mapper.Map<GetPlayerDto>(player);
        }

        public void RemovePlayerFromGame(int playerId)
        {
            var player = _playerRepository.GetById(playerId);
            if(player == null)
            {
                throw new ArgumentException("Player doesn't exist");// Revise excpetion
            }

            _playerRepository.Delete(player);
        }

        GetPlayerDto IPlayerService.GetPlayerById(int id)
        {
            var player = _playerRepository.GetById(id);
            if (player == null)
            {
                throw new ArgumentException("Player doesn't exist");// Revise excpetion
            }

            return _mapper.Map<GetPlayerDto>(player);
        }

        IList<GetPlayerDto> IPlayerService.GetAllPlayers()
        {
            var player = _playerRepository.GetAll();

            return _mapper.Map<IList<GetPlayerDto>>(player);
        }

        IList<GetPlayerDto> IPlayerService.GetAllPlayersByGameId(int gameId)
        {
            var player = _playerRepository.GetAll().Where(x=>x.GameId == gameId).ToList();

            return _mapper.Map<IList<GetPlayerDto>>(player);
        }
    }
}
