using Domain.Enums;

namespace Application.DTOs
{
    public class PlayerCardDto
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        public int PlayerId { get; set; }
    }
}
