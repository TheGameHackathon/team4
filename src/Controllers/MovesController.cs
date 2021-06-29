using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private readonly IGamesRepo gamesRepo;
        private readonly IMapper mapper;

        public MovesController(IGamesRepo gamesRepo, IMapper mapper)
        {
            this.gamesRepo = gamesRepo;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputDto userInput)
        {
            var game = gamesRepo.GetGameById(gameId);

            var gameDto = mapper.Map<GameDto>(game);
            //if (userInput.ClickedPos != null)
            //    game.Cells.First(c => c.Type == "color4").Pos = userInput.ClickedPos;
            return Ok(gameDto);
        }
    }
}