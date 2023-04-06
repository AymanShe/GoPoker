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
        public PlayerCardDto AssignCardToPlayer(PlayerCardDto cardDto)
        {
            var card = _mapper.Map<PlayerCard>(cardDto);
            var player = _playerRepository.GetById(card.PlayerId);
            if (player == null)
            {
                throw new ArgumentException("Player doesn't exist");// TODO: handle
            };

            card.PlayerId = player.Id;
            card.Player = player;
            _playerCardRepository.Update(card);

            return _mapper.Map<PlayerCardDto>(card);
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

        public IList<PlayerCard> GetAllPlayersCardsByPlayerId(int playerId)
        {
            return _playerCardRepository.GetAll().Where(p => p.PlayerId == playerId).ToList();
        }

        public IList<PlayerCardDto> GetAllPlayersCards()
        {
            return _mapper.Map<IList<PlayerCardDto>>(_playerCardRepository.GetAll());
        }

        public PlayerCard? GetPlayerCardById(int id)
        {
            return _playerCardRepository.GetById(id);
        }

        public void RemoveCardFromPlayer(PlayerCard card)
        {
            _playerCardRepository.Delete(card);
        }
    }
}
