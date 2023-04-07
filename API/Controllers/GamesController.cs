using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }


        // GET: api/<GamesController>
        [HttpGet]
        public IActionResult Get()
        {
            var games = _gameService.GetAllGames();
            return Ok(games);
        }

        // GET api/<GamesController>/5
        [HttpGet("{id}/Players")]
        public IActionResult Get(int id)
        {
            var players = _gameService.GetAllPlayersByGameId(id);
            if (players == null)
            {
                return NotFound();
            }

            var json = JsonConvert.SerializeObject(players);
            return Ok(json);
        }

        // POST api/<GamesController>
        [HttpPost]
        public IActionResult Post()
        {
            var game = _gameService.StartNewGame();
            return Ok(game);
        }

        // DELETE api/<GamesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _gameService.EndGame(id);
        }
    }
}
