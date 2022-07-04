using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.EventSource;
using thegame.Models;
using thegame.Models.DTO;
using thegame.Models.Entities;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private IGamesRepository _gamesRepository;
        private readonly IGameService gameService;

        public MovesController(IGamesRepository gamesRepository, IGameService gameService)
        {
            _gamesRepository = gamesRepository;
            this.gameService = gameService;
        }

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody] UserInputDto userInput)
        {
            if (userInput is null)
                return BadRequest();

            var game = _gamesRepository.FindById(gameId);

            var userInputMove = new UserInput((userInput.KeyPressed) switch
            {
                37 => Move.Left, //left;
                38 => Move.Up, //up;
                39 => Move.Right, //right
                40 => Move.Down, //down
                _ => Move.Empty
            });

            var nextGameState = gameService.MakeMove(game, userInputMove);
            Console.Write(Convert.ToChar(userInput.KeyPressed));
            return Ok(nextGameState);
        }
    }
}