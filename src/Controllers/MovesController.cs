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
        private IMapper _mapper;
        private IGamesRepository _gamesRepository;
        private readonly IGameService gameService;

        public MovesController(IMapper mapper, IGamesRepository gamesRepository, IGameService gameService)
        {
            _mapper = mapper;
            _gamesRepository = gamesRepository;
            this.gameService = gameService;
        }

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody] UserInputDto userInput)
        {
            if (userInput is null)
                return BadRequest();

            if (userInput.ClickedPos is null)
                return Ok();
            
            var game = _gamesRepository.FindById(gameId);

            if (game is null)
                return NotFound();

            var playerMove = userInput.KeyPressed switch
            {
                37 => //left
                    Move.Left,
                38 => //up
                    Move.Up,
                39 => //right
                    Move.Right,
                40 => //down
                    Move.Down,
                _ => Move.Up
            };

            gameService.MakeMove(game, );
            Console.Write(Convert.ToChar(userInput.KeyPressed));
            return Ok(game);
        }
    }
}