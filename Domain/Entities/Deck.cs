using Domain.Enums;

namespace Domain.Entities
{
    public struct Deck
    {
        public IList<Card> Cards { get; init; }

        public Deck()
        {
            Cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value value in Enum.GetValues(typeof(Value)))
                {
                    Cards.Add(new Card(suit, value));
                }
            }
        }
    }
}
