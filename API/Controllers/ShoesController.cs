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
        [HttpPut("{playerId}")]
        public IActionResult Put(int playerId)
        {
            var playerCardDto = _shoeService.DealCardToPlayer(playerId);

            return Ok(playerCardDto);
        }
    }
}
