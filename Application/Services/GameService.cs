using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IShoeRepository _shoeRepository;
        private readonly IShoeCardService _shoeCardService;
        private readonly IShoeService _shoeService;
        private readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IShoeRepository shoeRepository, IShoeCardService shoeCardService, IShoeService shoeService, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _shoeRepository = shoeRepository;
            _shoeCardService = shoeCardService;
            _shoeService = shoeService;
            _mapper = mapper;
        }

        public GameDto StartNewGame()
        {
            var game = new Game();
            _gameRepository.Add(game);

            var shoe = new Shoe()
            {
                GameId = game.Id,
                Game = game
            };
            _shoeRepository.Add(shoe);


            _shoeCardService.AddDeckToShoe(shoe.Id);
            _shoeService.ShuffleCards(shoe.Id);

            return _mapper.Map<GameDto>(game);
        }

        public void EndGame(int gameId)
        {
            var game = _gameRepository.GetById(gameId);
            if (game == null)
            {
                throw new ArgumentException("");// TODO revise
            }

            _gameRepository.Delete(game);
        }

        public List<GameDto> GetAllGames()
        {
            return _mapper.Map<List<GameDto>>(_gameRepository.GetAll());
        }

        public GameDto? GetGameById(int id)
        {
            var game = _gameRepository.GetById(id);
            if (game == null)
            {
                throw new ArgumentException("");// TOFO revise
            }

            return _mapper.Map<GameDto>(game);
        }

        public Dictionary<int, (int, int)> GetAllPlayersByGameId(int gameId)
        {
            var game = _gameRepository.GetById(gameId);
            // TODO check if null

            var players = game.Players;

            var result = new Dictionary<int, int>();

            foreach (var player in players)
            {
                result[player.Id] = 0;
                foreach (var card in player.Cards)
                {
                    result[player.Id] += (int)card.Rank;
                }
            }

            var orderedResult = result.ToList().OrderByDescending(x => x.Value).ToList();
            var orderedWithPosition = orderedResult.Select((x, i) => new { x.Key, x.Value, Position = i + 1 }).ToDictionary(x => x.Position, x => (x.Key ,x.Value));

            return orderedWithPosition;
        }
    }
}
