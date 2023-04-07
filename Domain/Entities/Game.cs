namespace Domain.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public virtual Shoe? Shoe { get; set; }
        public virtual ICollection<Player> Players { get; } = new List<Player>();
    }
}
