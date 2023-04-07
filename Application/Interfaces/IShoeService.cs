using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IShoeService
    {
        public PlayerCardDto DealCardToPlayer(int shoeId, int playerId);// TODO consider moving this to the GameService
        public IList<ShoeCardDto> ShuffleCards(int shoeId);
        public void UpdateNumberOfDecksAfterAdding(int shoeId);
    }
}