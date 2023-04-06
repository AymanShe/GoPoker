using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Player CreatePlayer(Player player)
        {
            _playerRepository.Add(player);
            return player;
        }

        public Player GetPlayerById(int id)
        {
            return _playerRepository.GetById(id);
        }

        public IList<Player> GetAllPlayers()
        {
            return _playerRepository.GetAll();
        }

        public IList<Player> GetAllPlayersByGameId(int gameId)
        {
            return _playerRepository.GetAll().Where(p => p.GameId == gameId).ToList();
        }

        public Player UpdatePlayer(Player player)
        {
            // TODO: add validation and null checks
            var playerInDb = _playerRepository.GetById(player.Id);

            playerInDb.IsPlaying = player.IsPlaying;
            playerInDb.GameId = player.GameId;

            _playerRepository.Update(playerInDb);

            return playerInDb;
        }

        public void DeletePlayer(Player player)
        {
            // TODO: add validation and null checks
            _playerRepository.Delete(player);
        }
    }
}
