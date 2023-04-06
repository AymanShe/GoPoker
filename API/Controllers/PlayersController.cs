using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }



        // GET: api/<PlayersController>
        [HttpGet]
        public IActionResult Get()//TODO: create player DTO
        {
            var players = _playerService.GetAllPlayers();
            return Ok(players);
        }

        // GET api/<PlayersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)//TODO: create player DTO
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
        public IActionResult Post([FromBody] Player newplayer)//TODO: create player DTO
        {
            var player = _playerService.CreatePlayer(newplayer);
            return Ok(player);
        }

        // PUT api/<PlayersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Player player)//TODO: create player DTO
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            var playerInDb = _playerService.UpdatePlayer(player);
            if (playerInDb == null)
            {
                return NotFound();
            }

            return Ok(playerInDb);
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

            _playerService.DeletePlayer(player);

            return NoContent();
        }
    }
}
