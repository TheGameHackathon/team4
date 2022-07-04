using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.EventSource;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody] UserInputDto userInput)
        {
            if (userInput is null)
                return BadRequest();

            var game = 
            
            if (userInput.ClickedPos is null)
                return Ok();

            switch (userInput.KeyPressed)
            {
                case 37: //left
                    break;
                case 38: //up
                    break;
                case 39: //right
                    break;
                case 40: //down
                    break;
            }
            Console.Write(Convert.ToChar(userInput.KeyPressed));
            return Ok(game);
        }
    }
}