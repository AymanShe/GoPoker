using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IShoeCardRepository
    {
        ShoeCard Add(ShoeCard shoeCard);
        ShoeCard? GetById(int id);
        IList<ShoeCard> GetAll();
        void Update(ShoeCard shoeCard);
        void Delete(ShoeCard shoeCard);
    }
}
