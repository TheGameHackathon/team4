using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private readonly GameManager games;

        public  MovesController(GameManager games)
        {
            this.games = games;
        }
        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            var game = games.GetGameById(gameId);
            if (userInput.ClickedPos != null)
            {
                var color = game.Cells.FirstOrDefault(c => c.Pos.Equals(userInput.ClickedPos)).Type;
                game.MakeMove(color);
            }
            else
            {
                game.MakeBestMove();
            }
            
            return new ObjectResult(game);
        }
    }
}