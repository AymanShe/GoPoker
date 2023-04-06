using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class PlayerCardRepository : IPlayerCardRepository
    {
        private readonly GoPokerDbContext _context;

        public PlayerCardRepository(GoPokerDbContext context)
        {
            _context = context;
        }
        public PlayerCard Add(PlayerCard playerCard)
        {
            _context.PlayerCards.Add(playerCard);
            _context.SaveChanges();

            return playerCard;
        }

        public void Delete(PlayerCard playerCard)
        {
            _context.PlayerCards.Remove(playerCard);
            _context.SaveChanges();
        }

        public IList<PlayerCard> GetAll()
        {
            return _context.PlayerCards.ToList();
        }

        public PlayerCard? GetById(int id)
        {
            return _context.PlayerCards.FirstOrDefault(p => p.Id == id);
        }

        public void Update(PlayerCard playerCard)
        {
            _context.PlayerCards.Update(playerCard);
            _context.SaveChanges();
        }
    }
}
