namespace Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
        public virtual Shoe Shoe { get; set; } = new();
    }
}
