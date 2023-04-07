namespace Application.DTOs
{
    public class GetPlayerDto
    {
        public int Id { get; set; }
        public ICollection<PlayerCardDto> Cards { get; } = new List<PlayerCardDto>();
        public bool IsPlaying { get; set; }
        public int? GameId { get; set; }
    }
}
