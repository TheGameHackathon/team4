using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.EventSource;
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