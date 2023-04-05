namespace Domain.Entities
{
    public class Game
    {
        public Shoe Shoe { get; set; }
        public IList<Player> Players { get; set; }

        public Game()
        {
            Shoe = new Shoe();
            Players = new List<Player>();
        }
    }
}
