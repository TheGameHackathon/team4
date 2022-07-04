using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Models.DTO;
using thegame.Models.Entities;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        private readonly IGamesRepository gameRepository;
        private readonly IMapper mapper;

        public GamesController(IGamesRepository gameRepository, IMapper mapper)
        {
            this.gameRepository = gameRepository;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Index()
        {
            var gameDto = TestData.FirstLevel();
            var game = mapper.Map<Game>(gameDto);
            gameRepository.Insert(game);
            return Ok(gameDto);
        }
    }
}