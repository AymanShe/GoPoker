using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPlayerService
    {
        GetPlayerDto AddPlayerToGame(AddPlayerDto player);
        void RemovePlayerFromGame(int playerId);
        GetPlayerDto GetPlayerById(int id);
        IList<GetPlayerDto> GetAllPlayers();
        IList<GetPlayerDto> GetAllPlayersByGameId(int gameId);
    }
}
