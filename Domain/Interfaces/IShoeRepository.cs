using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IShoeRepository
    {
        Shoe Add(Shoe shoe);
        Shoe? GetById(int id);
        IList<Shoe> GetAll();
        void Update(Shoe shoe);
        void Delete(Shoe shoe);
    }
}
