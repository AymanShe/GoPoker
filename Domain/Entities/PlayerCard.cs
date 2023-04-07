namespace Domain.Entities
{
    public class PlayerCard : Card
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; } = null!;
    }
}
