using Application.DTOs;
using Domain.Entities;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface IPlayerCardService
    {
        PlayerCard? GetPlayerCardById(int id);
        IList<PlayerCardDto> GetAllPlayersCards();
        IList<PlayerCard> GetAllPlayersCardsByPlayerId(int playerId);
        PlayerCardDto AssignCardToPlayer(PlayerCardDto cardDto);
        PlayerCard AssignCardToPlayer(Suit suit, Rank rank, int playerId);
        void RemoveCardFromPlayer(PlayerCard card);
    }
}
