using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace Application.Services
{
    public class PlayerCardService : IPlayerCardService
    {
        private readonly IPlayerCardRepository _playerCardRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayerCardService(IPlayerCardRepository playerCardRepository, IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerCardRepository = playerCardRepository;
            _playerRepository = playerRepository;
            _mapper = mapper;
        }
        public PlayerCardDto AssignCardToPlayer(PlayerCardDto playerCardDto)
        {
            var player = _playerRepository.GetById(playerCardDto.PlayerId);
            if (player == null)
            {
                throw new ArgumentException("Player doesn't exist");// TODO: handle
            };

            var playerCard = new PlayerCard
            {
                PlayerId = player.Id,
                Rank = playerCardDto.Rank,
                Suit = playerCardDto.Suit,
                Player = player// TODO do i really need this
            };

            _playerCardRepository.Add(playerCard);

            return _mapper.Map<PlayerCardDto>(playerCard);
        }

        public PlayerCard AssignCardToPlayer(Suit suit, Rank rank, int playerId)
        {
            var player = _playerRepository.GetById(playerId);
            if (player == null)
            {
                throw new ArgumentException("Player doesn't exist");// TODO: handle
            };

            var card = new PlayerCard
            {
                PlayerId = playerId,
                Suit = suit,
                Rank = rank,
                Player = player
            };

            card.PlayerId = player.Id;
            card.Player = player;
            _playerCardRepository.Update(card);

            return card;
        }

        public IList<PlayerCardDto> GetAllPlayersCardsByPlayerId(int playerId)
        {
            var cards = _playerCardRepository.GetAll().Where(p => p.PlayerId == playerId).ToList(); ;
            return _mapper.Map<IList<PlayerCardDto>>(cards);
        }

        public IList<PlayerCardDto> GetAllPlayersCards()
        {
            return _mapper.Map<IList<PlayerCardDto>>(_playerCardRepository.GetAll());
        }

        public PlayerCardDto? GetPlayerCardById(int id)
        {
            return _mapper.Map<PlayerCardDto>(_playerCardRepository.GetById(id));
        }
    }
}
