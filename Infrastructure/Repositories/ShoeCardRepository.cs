﻿using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class ShoeCardRepository : IShoeCardRepository
    {
        private readonly GoPokerDbContext _context;

        public ShoeCardRepository(GoPokerDbContext context)
        {
            _context = context;
        }
        public ShoeCard Add(ShoeCard shoeCard)
        {
            _context.ShoeCards.Add(shoeCard);
            _context.SaveChanges();

            return shoeCard;
        }

        public List<ShoeCard> AddRange(List<ShoeCard> shoeCards)
        {
            _context.AddRange(shoeCards);
            _context.SaveChanges();

            return shoeCards;
        }

        public void Delete(ShoeCard shoeCard)
        {
            _context.ShoeCards.Remove(shoeCard);
            _context.SaveChanges();
        }

        public IList<ShoeCard> GetAll()
        {
            return _context.ShoeCards.ToList();
        }

        public ShoeCard? GetById(int id)
        {
            return _context.ShoeCards.FirstOrDefault(p => p.Id == id);
        }

        public void Update(ShoeCard shoeCard)
        {
            _context.ShoeCards.Update(shoeCard);
            _context.SaveChanges();
        }

        public void UpdateAll (IList<ShoeCard> shoeCards)
        {
            _context.ShoeCards.UpdateRange(shoeCards);
            _context.SaveChanges();
        }
    }
}
