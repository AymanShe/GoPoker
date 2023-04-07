using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerCardsController : ControllerBase
    {
        private readonly IPlayerCardService _playerCardService;

        public PlayerCardsController(IPlayerCardService playerCardService)
        {
            _playerCardService = playerCardService;
        }
        // GET: api/<PlayrCardsController>
        [HttpGet]
        public IActionResult Get()
        {
            var playerCard = _playerCardService.GetAllPlayersCards();
            return Ok(playerCard);
        }

        // GET api/<PlayrCardsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var playerCard = _playerCardService.GetAllPlayersCardsByPlayerId(id);
            if(playerCard == null)
            {
                return NotFound();
            }

            return Ok(playerCard);
        }
    }
}
