namespace Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public Shoe? Shoe { get; set; }
        public ICollection<Player> Players { get; } = new List<Player>();
    }
}
