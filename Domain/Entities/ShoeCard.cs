namespace Domain.Entities
{
    public class ShoeCard : Card
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public int Position { get; set; }
        public Shoe Shoe { get; set; } = null!;
    }
}
