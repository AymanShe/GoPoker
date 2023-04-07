namespace Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public virtual ICollection<PlayerCard> Cards { get; } = new List<PlayerCard>();
        public bool IsPlaying { get; set; }
        public int? GameId { get; set; }
        public virtual Game? Game { get; set; }
    }
}
