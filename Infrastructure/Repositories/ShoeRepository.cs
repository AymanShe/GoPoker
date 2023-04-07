using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class ShoeRepository : IShoeRepository
    {
        private readonly GoPokerDbContext _context;

        public ShoeRepository(GoPokerDbContext context)
        {
            _context = context;
        }
        public Shoe Add(Shoe shoe)
        {
            _context.Shoes.Add(shoe);
            _context.SaveChanges();

            return shoe;
        }

        public void Delete(Shoe shoe)
        {
            _context.Shoes.Remove(shoe);
            _context.SaveChanges();
        }

        public IList<Shoe> GetAll()
        {
            return _context.Shoes.ToList();
        }

        public Shoe? GetById(int id)
        {
            return _context.Shoes.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Shoe shoe)
        {
            _context.Shoes.Update(shoe);
            _context.SaveChanges();
        }
    }
}
