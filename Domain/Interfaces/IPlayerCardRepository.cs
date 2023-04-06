using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPlayerCardRepository
    {
        PlayerCard Add(PlayerCard playerCard);
        PlayerCard? GetById(int id);
        IList<PlayerCard> GetAll();
        void Update(PlayerCard playerCard);
        void Delete(PlayerCard playerCard);
    }
}
