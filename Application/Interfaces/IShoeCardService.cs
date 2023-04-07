using Application.DTOs;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface IShoeCardService
    {
        Dictionary<Suit, int> GetCountForEachSuit(int shoeId);
        Dictionary<ShoeCardDto, int> GetCountForEachCard(int shoeId);
        List<ShoeCardDto> AddDeckToShoe(int shoeId);
    }
}
