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
        private readonly MapRepository _mapRepository;

        public MovesController(IGamesRepository gamesRepository, IGameService gameService, MapRepository mapRepository)
        {
            _gamesRepository = gamesRepository;
            this.gameService = gameService;
            _mapRepository = mapRepository;
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
                73 => Move.AI, //AI
                _ => Move.Empty
            });

            // foreach (var p in game.Cells)
            // {
                // if (game.targets.Contains(p.Pos))
                    // p.Type = "boxOnTarget";
            // }

            var nextGameState = gameService.MakeMove(game, userInputMove);
            Console.Write(Convert.ToChar(userInput.KeyPressed));
            
            var map = _mapRepository.GetMapByGameId(gameId);
            var targets = map.Targets.Select(p => (p.X, p.Y)).ToHashSet();
            var boxesOnTargets = game.Cells
                .Where(p => targets.Contains((p.Pos.X, p.Pos.Y)) && p.Type == "box");
            foreach (var boxOnTarget in boxesOnTargets)
                boxOnTarget.Type = "boxOnTarget";
            var boxesUntarget = game.Cells
                .Where(p => !targets.Contains((p.Pos.X, p.Pos.Y)) && p.Type == "boxOnTarget");
            foreach (var b in boxesUntarget)
                b.Type = "box";
            return Ok(nextGameState);
        }
    }
}