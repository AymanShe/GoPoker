using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IGameRepository
    {
        Game Add(Game game);
        Game? GetById(int id);
        List<Game> GetAll();
        void Update(Game game);
        void Delete(Game game);
    }
}
