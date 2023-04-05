using Domain.Common;

namespace Domain.Entities
{
    public class Player : BaseEntity
    {
        public IList<Card> Hand { get; set; } = new List<Card>();
        public bool IsPlaying { get; set; }
        public int? SeatNumber { get; set; }

        public int? GameId { get; set; }
        public Game? CurrentGame { get; set; }
    }
}
