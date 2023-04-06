using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace Application.Services
{
    public class PlayerCardService : IPlayerCardService
    {
        private readonly IPlayerCardRepository _playerCardRepository;
        private readonly IPlayerRepository _playerRepository;

        public PlayerCardService(IPlayerCardRepository playerCardRepository, IPlayerRepository playerRepository)
        {
            _playerCardRepository = playerCardRepository;
            _playerRepository = playerRepository;
        }
        public PlayerCard AssignCardToPlayer(PlayerCard card, int playerId)
        {
            var player = _playerRepository.GetById(playerId);
            if (player == null)
            {
                throw new ArgumentException("Player doesn't exist");// TODO: handle
            };

            card.PlayerId = player.Id;
            card.Player = player;
            _playerCardRepository.Update(card);

            return card;
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

        public IList<PlayerCard> GetAllPlayersCards()
        {
            return _playerCardRepository.GetAll();
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
