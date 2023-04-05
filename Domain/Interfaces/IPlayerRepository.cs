using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPlayerRepository
    {
        Player Add(Player player);
        Player GetById(int id);
        IList<Player> GetAll();
        void Update(Player player);
        void Delete(Player player);
    }
}
