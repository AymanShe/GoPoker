using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Shoe
    {
        public int Id { get; set; }
        public int NumberOfDecks { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; } = null!;
        public virtual ICollection<ShoeCard> Cards { get; } = new List<ShoeCard>();
        
    }
}
