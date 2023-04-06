using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPlayerCardService
    {
        PlayerCard? GetPlayerCardById(int id);
        IList<PlayerCard> GetAllPlayersCards();
        IList<PlayerCard> GetAllPlayersCardsByPlayerId(int playerId);
        PlayerCard AssignCardToPlayer(PlayerCard card, int playerId);
        PlayerCard AssignCardToPlayer(Suit suit, Rank rank, int playerId);
        void RemoveCardFromPlayer(PlayerCard card);
    }
}
