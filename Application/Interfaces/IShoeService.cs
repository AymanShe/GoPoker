using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IShoeService
    {
        public void ShuffleCard(int shoeId);
        public PlayerCardDto DealCardToPlayer(int shoeId, int playerId);// TODO consider moving this to the GameService
        public void UpdateNumberOfDecksAfterAdding(int shoeId);
    }
}