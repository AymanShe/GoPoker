using Application.Interfaces;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeCardsController : ControllerBase
    {
        private readonly IShoeCardService _shoeCardService;

        public ShoeCardsController(IShoeCardService shoeCardService)
        {
            _shoeCardService = shoeCardService;
        }

        // GET api/<ShoeCardsController>/5
        [HttpGet("{id}/All")]
        public IActionResult GetAll(int id)
        {
            var shoeCards = _shoeCardService.GetCountForEachCard(id);
            return Ok(shoeCards);
        }

        // GET api/<ShoeCardsController>/5
        [HttpGet("{id}/Suit")]
        public IActionResult GetGrouped(int id)
        {
            var shoeCards = _shoeCardService.GetCountForEachSuit(id);
            return Ok(shoeCards);
        }

        // PUT api/<ShoeCardsController>/5
        [HttpPut("{id}/AddDeck")]
        public IActionResult Put(int id)
        {
            _shoeCardService.AddDeckToShoe(id);
            return Ok();
        }
    }
}
