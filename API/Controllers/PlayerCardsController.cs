using API.DTOs;
using Application.Interfaces;
using Domain.Entities;
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
            var playerCard = _playerCardService.GetPlayerCardById(id);
            if(playerCard == null)
            {
                return NotFound();
            }

            return Ok(playerCard);
        }
        /// <summary>
        /// Deals the card to the player with the provided Player ID
        /// </summary>
        /// <param name="card">Suit and Rank of the card as numbers</param>
        /// <param name="PlayerId">The ID of the player the card will dealt to</param>
        /// <returns></returns>
        // POST api/<PlayrCardsController>
        [HttpPost]
        public IActionResult Post([FromBody] PlayerCard card, int PlayerId)
        {
            var cardInDb = _playerCardService.AssignCardToPlayer(card, PlayerId);
            return Ok(cardInDb);
        }
        /// <summary>
        /// Removes the card with the ID provided from the player who is holding it
        /// </summary>
        /// <param name="id">The ID of the player card</param>
        /// <returns></returns>
        // DELETE api/<PlayrCardsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var card = _playerCardService.GetPlayerCardById(id);
            if(card == null)
            {
                return NotFound();
            }

            _playerCardService.RemoveCardFromPlayer(card);

            return Ok();
        }
    }
}
