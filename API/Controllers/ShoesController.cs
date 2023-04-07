using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
        private readonly IShoeService _shoeService;

        public ShoesController(IShoeService shoeService)
        {
            _shoeService = shoeService;
        }

        // PUT api/<ShoesController>/5
        [HttpPut("{id}/deal/{playerId}")]
        public IActionResult Put(int id, int playerId)
        {
            var playerCardDto = _shoeService.DealCardToPlayer(id, playerId);

            return Ok(playerCardDto);
        }

        // PUT api/<ShoesController>/5
        [HttpPut("{id}/shuffle")]
        public IActionResult Put(int id)
        {
            _shoeService.ShuffleCards(id);

            return Ok();
        }
    }
}
