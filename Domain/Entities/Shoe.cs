namespace Domain.Entities
{
    public class Shoe
    {
        public int NumberOfDecks { get; set; }
        public IList<Card> Cards { get; set; }

        public Shoe()
        {
            Cards = new List<Card>();
        }
    }
}
