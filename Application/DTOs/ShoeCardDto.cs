using Domain.Enums;

namespace Application.DTOs
{
    public class ShoeCardDto
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        public int Position { get; set; }
        public int ShoeId { get; set; }
    }
}
