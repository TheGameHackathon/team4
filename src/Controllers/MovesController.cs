using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Models.DTO;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private IMapper _mapper;
        private IGamesRepository _gamesRepository;

        public MovesController(IMapper mapper, IGamesRepository gamesRepository)
        {
            _mapper = mapper;
            _gamesRepository = gamesRepository;
        }

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody] UserInputDto userInput)
        {
            var game = TestData.AGameDto(userInput.ClickedPos ?? new VectorDto {X = 1, Y = 1});
            if (userInput.ClickedPos != null)
                game.Cells.First(c => c.Type == "color4").Pos = userInput.ClickedPos;
            return Ok(game);
        }
    }
}