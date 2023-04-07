using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;

namespace Application.Services
{
    public class ShoeCardService : IShoeCardService
    {
        private readonly IShoeCardRepository _shoeCardRepository;
        private readonly IShoeService _shoeService;
        private readonly IMapper _mapper;

        public ShoeCardService(IShoeCardRepository shoeCardRepository, IShoeService shoeService, IMapper mapper)
        {
            _shoeCardRepository = shoeCardRepository;
            _shoeService = shoeService;
            _mapper = mapper;
        }


        public List<ShoeCardDto> AddDeckToShoe(int shoeId)
        {
            var lastCard = _shoeCardRepository.GetAll().OrderByDescending(x => x.Position).FirstOrDefault();
            var position = lastCard?.Position ?? 0;

            var deck = new List<ShoeCard>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    position++;
                    deck.Add(new ShoeCard { Rank = rank, Suit = suit, Position = position, ShoeId = shoeId });
                }
            }

            _shoeCardRepository.AddRange(deck);
            _shoeService.UpdateNumberOfDecksAfterAdding(shoeId);
            _shoeService.ShuffleCards(shoeId);

            return _mapper.Map<List<ShoeCardDto>>(deck);
        }

        public Dictionary<ShoeCardDto, int> GetCountForEachCard(int shoeId)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Suit, int> GetCountForEachSuit(int shoeId)
        {
            var cardsBySuit = new Dictionary<Suit, int>
            {
                { Suit.Hearts, 0 },
                { Suit.Spades, 0 },
                { Suit.Clubs, 0 },
                { Suit.Diamonds, 0 }
            };

            var shoeCards = _shoeCardRepository.GetAll().Where(sc => sc.ShoeId == shoeId);

            shoeCards.ToList().ForEach(x => cardsBySuit[x.Suit]++);

            return cardsBySuit;
        }
    }
}
