using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public PlayersController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
        }



        // GET: api/<PlayersController>
        [HttpGet]
        public IActionResult Get()
        {
            var players = _playerService.GetAllPlayers();
            return Ok(players);
        }

        // GET api/<PlayersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var player = _playerService.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        // POST api/<PlayersController>
        [HttpPost]
        public IActionResult Post([FromBody] AddPlayerDto playerDto)
        {
            var player = _playerService.AddPlayerToGame(playerDto);
            return Ok(player);
        }

        // DELETE api/<PlayersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var player = _playerService.GetPlayerById(id);
            if (player == null)
            {
                return NotFound();
            }

            _playerService.RemovePlayerFromGame(id);

            return NoContent();
        }
    }
}
