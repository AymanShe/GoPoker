using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IShoeCardRepository
    {
        ShoeCard Add(ShoeCard shoeCard);
        List<ShoeCard> AddRange(List<ShoeCard> shoeCards);
        ShoeCard? GetById(int id);
        IList<ShoeCard> GetAll();
        void Update(ShoeCard shoeCard);
        void UpdateAll(IList<ShoeCard> shoeCards);
        void Delete(ShoeCard shoeCard);
    }
}
