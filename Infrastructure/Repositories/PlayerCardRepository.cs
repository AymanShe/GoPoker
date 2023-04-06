using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
