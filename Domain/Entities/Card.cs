using Domain.Enums;

namespace Domain.Entities
{
    public abstract class Card
    {
        public Suit Suit { get; init; }
        public Rank Rank { get; init; }
    }
}
