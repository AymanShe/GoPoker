using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGameService
    {
        List<GameDto> GetAllGames();
        GameDto? GetGameById(int id);
        GameDto StartNewGame();
        void EndGame(int gameId);
        Dictionary<int, (int PlayerId, int Score)> GetAllPlayersByGameId(int gameId);
    }
}
