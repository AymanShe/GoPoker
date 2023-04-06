using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    internal class GameRepository : IGameRepository
    {
        private readonly GoPokerDbContext _context;

        public GameRepository(GoPokerDbContext context)
        {
            _context = context;
        }
        public Game Add(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();

            return game;
        }

        public void Delete(Game game)
        {
            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        public IList<Game> GetAll()
        {
            return _context.Games.ToList();
        }

        public Game? GetById(int id)
        {
            return _context.Games.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Game game)
        {
            _context.Games.Update(game);
            _context.SaveChanges();
        }
    }
}
