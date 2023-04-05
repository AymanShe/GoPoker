using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPlayerService
    {
        Player CreatePlayer(Player player);
        Player GetPlayerById(int id);
        IList<Player> GetAllPlayers();
        IList<Player> GetAllPlayersByGameId(int gameId);
        Player UpdatePlayer(Player player);
        void DeletePlayer(Player player);
    }
}
