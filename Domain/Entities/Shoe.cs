using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Shoe
    {
        [ForeignKey(nameof(Game))]
        public int Id { get; set; }
        public int NumberOfDecks { get; set; }
        public ICollection<ShoeCard> Cards { get; set; } = new List<ShoeCard>();
        
    }
}
