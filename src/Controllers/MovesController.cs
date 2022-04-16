using System;
using Microsoft.AspNetCore.Mvc;
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
            var game = GamesRepo.GetOrCreate(gameId);
            
            switch ((char)userInput.KeyPressed)
            {
                case 'W':
                    game.MoveUp();
                    break;
                case 'A':
                    game.MoveLeft();
                    break;
                case 'S':
                    game.MoveDown();
                    break;
                case 'D':
                    game.MoveRight();
                    break;
            }

            return Ok(game);
        }
    }
}