namespace Domain.Entities
{
    public class Player
    {
        public int SeatNumber { get; set; }
        public IList<Card> Hand { get; set; }// TODO: could be it's own class to add count and combined value of cards

        public Player(int seatNumber)
        {
            SeatNumber = seatNumber;
            Hand = new List<Card>();
        }
    }
}
