using Domain.Common;

namespace Domain.Entities
{
    public class Game : BaseEntity
    {
        public Shoe Shoe { get; set; } = new();
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}
