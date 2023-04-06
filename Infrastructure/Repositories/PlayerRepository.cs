using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly GoPokerDbContext _context;

        public PlayerRepository(GoPokerDbContext context)
        {
            _context = context;
        }

        public Player Add(Player player)
        {
            _context.Add(player);
            _context.SaveChanges();

            return player;
        }

        public Player? GetById(int id)
        {
            // TODO: add validation and null checks
            return _context.Players.FirstOrDefault(p => p.Id == id);
        }

        public IList<Player> GetAll()
        {
            return _context.Players.ToList();
        }

        public void Update(Player player)
        {
            _context.Players.Update(player);
            _context.SaveChanges();
        }

        public void Delete(Player player)
        {
            _context.Players.Remove(player);
            _context.SaveChanges();
        }
    }
}
