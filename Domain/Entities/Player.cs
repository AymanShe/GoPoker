namespace Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public ICollection<PlayerCard> Hand { get; set; } = new List<PlayerCard>();
        public bool IsPlaying { get; set; }

        public int? GameId { get; set; }
        public Game? CurrentGame { get; set; }
    }
}
