using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;
using thegame.Services.Abstractions;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private readonly IMoveService _moveService;

        public MovesController(IMoveService moveService)
        {
            _moveService = moveService;
        }

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            GameDto game = _moveService.GetMove(userInput);

           
            return new ObjectResult(game);
        }
    }
}